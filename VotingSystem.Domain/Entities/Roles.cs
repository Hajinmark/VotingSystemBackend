using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Domain.Entities
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public ICollection<Users>? Users { get; set; } = new List<Users>();
        public Roles(string roleName)
        {
            RoleName = roleName;    
        }
    }
}
