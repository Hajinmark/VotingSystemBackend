using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Persistence;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Exceptions;
using VotingSystem.Application.Features.Roles.Command.CreateRoles;
using VotingSystem.Application.Utilities;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Features.Positions.Command
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, CreatePositionRequest>
    {
        private readonly IPositionRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CreatePositionCommandHandler(IPositionRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<CreatePositionRequest> Handle(CreatePositionCommand request)
        {
            try
            {
                var position = await repository.
                IsElectionPositionExist(request.ElectionId, request.PositionName, request.DisplayOrder);

                if (position == Domain.Enums.PositionValidationResult.NameAlreadyExists)
                    throw new AlreadyExistsException("Position Name already exist");

                if (position == Domain.Enums.PositionValidationResult.DisplayOrderAlreadyExists)
                    throw new AlreadyExistsException("Display Order already exist");

                var data = new Position()
                {
                    ElectionId = request.ElectionId,
                    Name = request.PositionName,
                    Description = request.Description,
                    DisplayOrder = request.DisplayOrder,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await this.repository.Add(data);
                await this.unitOfWork.Commit();

                return new CreatePositionRequest()
                { 
                    ElectionId = data.ElectionId,
                    PositionName = data.Name,
                    Description = data.Description,
                    DisplayOrder = data.DisplayOrder
                };


            }
            catch
            {
                await this.unitOfWork.Rollback();
                throw;
            }
           
        }
    }
}
