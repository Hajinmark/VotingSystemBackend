using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.API.DTO.Users;
using VotingSystem.Application.Features.Users.Command.CreateUser;
using VotingSystem.Application.Features.Users.Command.LoginUser;
using VotingSystem.Application.Utilities;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("CreateNewUser")]
        public async Task<ActionResult<string>> CreateNewUser(DTO.Users.UsersDTO request)
        {
            var command = new CreateUserCommand()
            {
                Username = request.Username,
                PasswordHash = request.PasswordHash,
                Role = request.Role,
                FirstName = request.UserDetails.FirstName,
                LastName = request.UserDetails.LastName,
                Email = request.UserDetails.Email,
            };

           var result = await mediator.Send(command);
           return Ok(result);
          
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult> LoginUser(LoginRequest request)
        {
            var command = new LoginUserCommand() 
            {
               Username = request.Username,
               Email = request.Email,
               PasswordHash = request.Password
            };

            var result = await mediator.Send(command);
            return Ok(result);

        }
    }

}
