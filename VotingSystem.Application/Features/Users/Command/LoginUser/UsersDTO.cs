using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Application.Features.Users.Command.LoginUser
{
    public class UsersDTO 
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int RoleId { get; set; }

        public UserDetailsDTO ? UserDetails { get; set; }
        public RolesDTO ? Roles { get; set; }
    }

    public class UserDetailsDTO
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class RolesDTO
    {
        public string RoleName { get; set; } = null!;
    }
}
