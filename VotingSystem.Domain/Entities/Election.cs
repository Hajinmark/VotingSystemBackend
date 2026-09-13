using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Domain.Entities
{
    public class Election
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; } // FK of Users who created
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Property
        public ICollection<UserElection> UserElections { get; set; } = new List<UserElection>();
        public ICollection<Position> Positions { get; set; } = new List<Position>();
        public Election(string title, string description, DateTime startDate, DateTime endDate, int status, int createdBy, DateTime createdAt, DateTime updatedAt)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            CreatedBy = createdBy;  
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

    }
}
