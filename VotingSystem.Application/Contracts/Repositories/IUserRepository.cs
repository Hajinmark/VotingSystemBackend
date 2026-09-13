using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Domain.Entities;
using VotingSystem.Application.Features.Users.Command.LoginUser;

namespace VotingSystem.Application.Contracts.Repositories
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<string> IsEmailOrUsernameExist(string ?username, string ? email);
        Task<UsersDTO> GetByUsername(string username);
    }
}
