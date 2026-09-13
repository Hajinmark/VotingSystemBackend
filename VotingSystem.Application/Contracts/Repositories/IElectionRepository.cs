using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Contracts.Repositories
{
    public interface IElectionRepository : IRepository<Election>
    {
        Task<int> IsElectionTitleExist(string title);
        Task<string> AddUserElection(UserElection request);
        Task<List<GetElectionResponse>> GetElections();
    }
}
