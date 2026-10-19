using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.DTO.Positions
{
    public class GetPositionsDTO
    {
        public int PositionID { get; set; }
        public int ElectionID { get; set; }
        public string ElectionName { get; set; } = null!;
        public string PositionName { get; set; } = null!;
        public string ? PositionDescription { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string DateCreated { get; set; } = null!;
    }
}
