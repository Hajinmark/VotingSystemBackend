using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application.Features.Elections.Command.UpdateElection
{
    public class UpdateElectionCommand : IRequest<UpdateElectionRequest>
    {
        public int ElectionID { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
    }
}
