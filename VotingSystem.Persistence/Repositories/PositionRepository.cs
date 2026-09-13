using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Exceptions;
using VotingSystem.Domain.Entities;
using VotingSystem.Domain.Enums;

namespace VotingSystem.Persistence.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly VotingSystemDbContext context;
        public PositionRepository(VotingSystemDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<PositionValidationResult> IsElectionPositionExist(int electionId, string positionName, int displayOrder)
        {
            try
            {
                bool isPositionExistInElection = await context.Positions.
                    AnyAsync(x => x.Name == positionName && 
                    x.ElectionId == electionId);

                bool isDisplayOrderExist = await context.Positions.AnyAsync(x => x.Name == positionName &&
                x.ElectionId == electionId && x.DisplayOrder == displayOrder);

                if (isPositionExistInElection)
                    return PositionValidationResult.NameAlreadyExists;

                if (isDisplayOrderExist)
                    return PositionValidationResult.DisplayOrderAlreadyExists;

                return PositionValidationResult.Valid;
            }
            catch
            {
                throw;
            }
            
        }
    }
}
