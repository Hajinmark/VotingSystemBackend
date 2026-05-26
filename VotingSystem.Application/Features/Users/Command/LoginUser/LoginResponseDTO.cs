using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Application.Features.Users.Command.LoginUser
{
    public class LoginResponseDTO
    {
        public string? Token { get; set; }
        public string? Username { get; set; }
        public string Message { get; set; } = string.Empty;
        public Boolean Success { get; set; }
    }
}
