using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Domain.Entities
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; } //FK
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public Users Users { get; set; } = null!;
        public UserDetails(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;    
            Email = email;
        }
    }
}

