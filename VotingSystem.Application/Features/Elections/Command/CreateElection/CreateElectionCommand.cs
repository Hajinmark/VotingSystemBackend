using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Utilities;
using VotingSystem.Application.DTO.Elections;

namespace VotingSystem.Application.Features.Elections.Command.CreateElection
{
    public class CreateElectionCommand : IRequest<CreateElectionsRequest>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
