using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Persistence
{
    public class VotingSystemDbContext : DbContext
    {
        public VotingSystemDbContext(DbContextOptions<VotingSystemDbContext> options) : base(options)
        {
        }
        //protected VotingSystemDbContext()
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VotingSystemDbContext).Assembly);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

    }
}
