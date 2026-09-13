using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.API.DTO.Elections;
using VotingSystem.Application.Features.Elections.Command.CreateElection;
using VotingSystem.Application.Features.Elections.Query.ElectionStatus;
using VotingSystem.Application.Features.Elections.Query.GetElections;
using VotingSystem.Application.Features.Roles.Command.CreateRoles;
using VotingSystem.Application.Utilities;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionController : ControllerBase
    {
        private readonly IMediator mediator;
        public ElectionController(IMediator mediator)
        {
            this.mediator = mediator;   
        }

        [HttpPost("CreateElection")]
        public async Task<ActionResult<CreateElectionDTO>> CreateElection(CreateElectionDTO request)
        {
            var command = new CreateElectionCommand()
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = request.Status,
                CreatedBy = request.CreatedBy
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetElectionStatus")]
        public async Task<ActionResult<ElectionsStatusDTO>> GetElectionStatus()
        {
            var command = new GetElectionStatusQuery();
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("GetElections")]
        public async Task<ActionResult<List<GetElectionsDTO>>> GetElections()
        {
            var command = new GetElectionsQuery();
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
