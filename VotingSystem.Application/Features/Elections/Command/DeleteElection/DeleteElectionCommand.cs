using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application.Features.Elections.Command.DeleteElection
{
    public class DeleteElectionCommand : IRequest<string>
    {
        public int ElectionID { get; set; }
    }
}
