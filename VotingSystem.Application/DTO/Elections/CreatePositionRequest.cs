using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Application.DTO.Elections
{
    public class CreatePositionRequest
    {
        public int ElectionId { get; set; }
        public string PositionName { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
