using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Domain.Entities;
using VotingSystem.Domain.Enums;

namespace VotingSystem.Application.Contracts.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<PositionValidationResult> IsElectionPositionExist(int electionId, string electionName, int displayOrder);
    }
}
