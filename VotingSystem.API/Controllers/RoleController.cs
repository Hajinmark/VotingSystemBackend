using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.API.DTO.Roles;
using VotingSystem.Application.Features.Roles.Command.CreateRoles;
using VotingSystem.Application.Utilities;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediator;
        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("CreateRoles")]
        public async Task<ActionResult<string>> CreateRoles(RolesDTO request)
        {
            var command = new CreateRolesCommand()
            { 
                RoleName = request.RoleName
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }

    }
}
