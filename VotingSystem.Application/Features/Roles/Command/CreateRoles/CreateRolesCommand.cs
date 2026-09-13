using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application.Features.Roles.Command.CreateRoles
{
    public class CreateRolesCommand : IRequest<string>
    {
        public string RoleName { get; set; }
    }
}
