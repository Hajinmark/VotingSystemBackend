using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Application.DTO.Elections
{
    public class CreateUserElectionRequest
    {
        public int UserId { get; set; }
        public int ElectionId { get; set; }
    }
}
