using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.API.DTO.Elections;
using VotingSystem.Application.Features.Elections.Command.CreateElection;
using VotingSystem.Application.Features.Elections.Command.DeleteElection;
using VotingSystem.Application.Features.Elections.Command.UpdateElection;
using VotingSystem.Application.Features.Elections.Query.ElectionStatus;
using VotingSystem.Application.Features.Elections.Query.FilterElection;
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

        [HttpDelete("DeleteElection")]
        public async Task<ActionResult<string>> DeleteElection(int Id)
        {
            var command = new DeleteElectionCommand
            {
                ElectionID = Id
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("FilterElectionByName")]
        public async Task<ActionResult<List<GetElectionsDTO>>> FilterElectionByName(string electionName)
        {
            var command = new FilterElectionQuery
            {
                ElectionName = electionName 
            };

            var result = await mediator.Send(command);
            return Ok(result);
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

        [HttpPut("UpdateElection")]
        public async Task<ActionResult<UpdateElectionDTO>> UpdateElection(UpdateElectionDTO request)
        {
            var command = new UpdateElectionCommand()
            {
                ElectionID = request.ElectionID,
                Title = request.ElectionName,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = request.ElectionStatus
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
