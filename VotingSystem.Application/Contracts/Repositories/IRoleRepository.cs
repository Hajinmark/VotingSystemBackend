using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Contracts.Repositories
{
    public interface IRoleRepository : IRepository<Roles>
    {
        Task<string> IsRoleExist(string role);
    }
}
