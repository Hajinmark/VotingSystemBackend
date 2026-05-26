using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.Exceptions;
using VotingSystem.Application.Features.Users.Command.LoginUser;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Persistence.Repositories
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        private readonly VotingSystemDbContext context;

        public UserRepository(VotingSystemDbContext context) : base(context) 
        {
            this.context = context;
        }

        public async Task<UsersDTO> GetByUsername(string username, string email)
        {
            
            var user = await context.Users
                .Include(x => x.UserDetails)
                .FirstOrDefaultAsync(x => x.Username == username || 
                (x.UserDetails != null && x.UserDetails.Email == email));

            try
            {
                if (user == null)
                    return null;

                var dto = new UsersDTO()
                {
                    Id = user.Id,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    Role = user.Role,
                    UserDetails = new UserDetailsDTO
                    {

                        FirstName = user.UserDetails?.FirstName ?? "",
                        LastName = user.UserDetails?.LastName ?? "",
                        Email = user.UserDetails?.Email ?? "",
                    }
                };

                return dto;
            }
            catch
            {
                throw;
            }
           
        }

        public async Task<string> IsEmailOrUsernameExist(string? username, string ? email)
        {
            try
            {
                var isEmailExist = await context.UserDetails
                    .AnyAsync(x => x.Email == email);

                var isUsernameExist = await context.Users
                    .AnyAsync(x => x.Username == username);

                if (isEmailExist == true)
                    return "Email Exist";

                if (isUsernameExist == true)
                    return "Username Exist";

                return "Both email and username not exist";

            }
            catch
            {
                throw;
            }
            
        }
    }
}
