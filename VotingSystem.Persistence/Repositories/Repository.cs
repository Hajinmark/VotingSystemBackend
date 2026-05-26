using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Repositories;

namespace VotingSystem.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly VotingSystemDbContext context;

        public Repository(VotingSystemDbContext context)
        {
            this.context = context;
        }

        public Task<T> Add(T entity)
        {
            context.Add(entity);
            return Task.FromResult(entity);
        }

        public Task Delete(T entity)
        {
            context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public Task Update(T entity)
        {
            context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
