using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.DTO.Positions;
using VotingSystem.Application.Exceptions;
using VotingSystem.Application.Features.Positions.Query.GetPositions;
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

                //bool isDisplayOrderExist = await context.Positions
                //    .AnyAsync(x => x.Name == positionName &&
                //    x.ElectionId == electionId && 
                //    x.DisplayOrder == displayOrder);

                bool isDisplayOrderExist = await context.Positions
                    .AnyAsync(x => x.ElectionId == electionId &&
                    x.DisplayOrder == displayOrder);

                bool isElectionExist = await context.Elections
                    .AnyAsync(x => x.Id == electionId);

                if (!isElectionExist)
                    return PositionValidationResult.ElectionDoesNotExist;

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

        public async Task<List<GetPositionsDTO>> RetrievePositionsData(GetPositionsQuery data)
        {
            var query = from p in context.Positions
                        join e in context.Elections
                            on p.ElectionId equals e.Id
                        select new GetPositionsDTO()
                        {
                            PositionID = p.Id,
                            ElectionID = p.ElectionId,
                            ElectionName = e.Title,
                            PositionName = p.Name,
                            PositionDescription = p.Description,
                            DisplayOrder = p.DisplayOrder,
                            CreatedAt = p.CreatedAt,
                            UpdatedAt = p.UpdatedAt,
                            DateCreated = p.CreatedAt.ToString("MMMM dd, yyyy")  
                        };

            // Filtering
            if (!string.IsNullOrEmpty(data.ElectionName))
                query = query.Where(x => x.ElectionName.Contains(data.ElectionName ?? ""));

            if (!string.IsNullOrEmpty(data.PositionName))
                query = query.Where(x => x.PositionName == data.PositionName);

            return await query.ToListAsync();
        }
    }
}
