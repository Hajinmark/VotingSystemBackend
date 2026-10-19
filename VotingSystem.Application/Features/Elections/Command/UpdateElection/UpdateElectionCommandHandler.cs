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

namespace VotingSystem.Application.Features.Elections.Command.UpdateElection
{
    public class UpdateElectionCommandHandler : IRequestHandler<UpdateElectionCommand, UpdateElectionRequest>
    {
        private readonly IRepository<Election> repository;
        private readonly IUnitOfWork unitOfWork;
        public UpdateElectionCommandHandler(IRepository<Election> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UpdateElectionRequest> Handle(UpdateElectionCommand request)
        {
            var data = await repository.GetById(request.ElectionID);

            if (data == null)
                return null;

            if (request.EndDate > request.StartDate)
                throw new Exception("End Date must not be higher than Start Date");

            data.Title = request.Title;
            data.Description = request.Description;
            data.StartDate = request.StartDate;
            data.EndDate = request.EndDate;
            data.Status = request.Status;

            await repository.Update(data);
            await unitOfWork.Commit();

            return new UpdateElectionRequest()
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = request.Status,
                UpdatedAt = DateTime.UtcNow 
            };
        }
    }
}
