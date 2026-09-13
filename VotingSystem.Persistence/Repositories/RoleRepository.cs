using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Persistence.Repositories
{
    public class RoleRepository : Repository<Roles>, IRoleRepository
    {
        private readonly VotingSystemDbContext context;
        public RoleRepository(VotingSystemDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<string> IsRoleExist(string role)
        {
            var roleName = await context.Roles.AnyAsync(x => x.RoleName == role);

            if (roleName)
                return "Exist";

            else
                return "Not Exist";
        }
    }
}
