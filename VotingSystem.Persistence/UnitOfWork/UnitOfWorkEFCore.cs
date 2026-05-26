using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Persistence;

namespace VotingSystem.Persistence.UnitOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly VotingSystemDbContext context;

        public UnitOfWorkEFCore(VotingSystemDbContext context)
        {
            this.context = context;
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
