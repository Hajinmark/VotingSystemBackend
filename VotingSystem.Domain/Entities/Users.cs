using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Domain.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Users() { }

        // Navigation Property
        public UserDetails ? UserDetails { get; set; }
        public Roles? Roles { get; set; }
        //public ICollection<Election> Elections { get; set; }  = new List<Election>();
        public ICollection<UserElection> UserElections { get; set; } = new List<UserElection>();
        public Users(string username, string passwordHash, int roleid)
        {
            Username = username;
            PasswordHash = passwordHash;
            RoleId = roleid;    
        }
    }
}
