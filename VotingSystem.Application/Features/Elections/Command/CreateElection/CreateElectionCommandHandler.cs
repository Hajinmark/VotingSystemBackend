using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Persistence;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Utilities;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Features.Elections.Command.CreateElection
{
    public class CreateElectionCommandHandler : IRequestHandler<CreateElectionCommand, CreateElectionsRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IElectionRepository electionRepository;
        private readonly IMapper mapper;
        public CreateElectionCommandHandler(IUnitOfWork unitOfWork, IElectionRepository electionRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.electionRepository = electionRepository;
            this.mapper = mapper;   
        }
        public async Task<CreateElectionsRequest> Handle(CreateElectionCommand request)
        {
            try
            {
                var isExist = await this.electionRepository.IsElectionTitleExist(request.Title);

                if(isExist != 0)
                    throw new Exception("Title name already exist");

                if(request.StartDate > request.EndDate)
                    throw new Exception("Start Date should not be greater than End Date");

                var election = new Election
                (
                    request.Title,
                    request.Description ?? "",
                    request.StartDate,
                    request.EndDate,
                    request.Status,
                    request.CreatedBy,
                    request.CreatedAt = DateTime.Now,
                    request.UpdatedAt = DateTime.Now
                );

                await this.electionRepository.Add(election);
                await this.unitOfWork.Commit();

                var userElection = new UserElection(
                    request.CreatedBy,
                    election.Id
                );

                await this.electionRepository.AddUserElection(userElection);
                await this.unitOfWork.Commit();

                var response = mapper.Map<CreateElectionsRequest>(election);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
