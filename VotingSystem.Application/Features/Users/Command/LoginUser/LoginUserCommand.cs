using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application.Features.Users.Command.LoginUser
{
    public class LoginUserCommand : IRequest<LoginResponseDTO>
    {
        public string ? Username { get; set; }
        public string ? Email { get; set; }
        public string PasswordHash { get; set; } = null!;
    }
}
