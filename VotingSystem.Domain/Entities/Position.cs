using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Domain.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public int ElectionId { get; set; } // FK of Election
        public string Name { get; set; } = null!;
        public string ? Description { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Property
        public Election Election { get; set; } = null!;

    }
}
