using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.API.DTO.Positions;
using VotingSystem.Application.Features.Positions.Command;
using VotingSystem.Application.Utilities;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IMediator mediator;
        public PositionController(IMediator mediator)
        {
            this.mediator = mediator;   
        }

        [HttpPost("CreatePosition")]
        public async Task<ActionResult<CreatePositionDTO>> CreatePosition(CreatePositionDTO request)
        {
            try
            {
                var command = new CreatePositionCommand()
                {
                    ElectionId = request.ElectionId,
                    PositionName = request.PositionName,
                    Description = request.Description,
                    DisplayOrder = request.DisplayOrder
                };

                var result = await mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
           
        }
    }
}
