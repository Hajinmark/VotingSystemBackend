using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Domain.Entities
{
    public class UserElection
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; } = null!;
        public int ElectionId { get; set; }
        public Election Election { get; set; } = null!;

        public UserElection(int userId , int electionId)
        {
            UserId = userId;
            ElectionId = electionId;
        }
    }
}
