using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application.Features.Positions.Command
{
    public class CreatePositionCommand : IRequest<CreatePositionRequest>
    {
        public int ElectionId { get; set; }
        public string PositionName { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
