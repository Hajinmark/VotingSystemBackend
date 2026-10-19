using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Application.DTO.Elections
{
    public class UpdateElectionRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
