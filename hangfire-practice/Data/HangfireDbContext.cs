using hangfire_practice.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace hangfire_practice.Data
{
    public class HangfireDbContext : DbContext
    {
        public HangfireDbContext(DbContextOptions<HangfireDbContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HangfireDbContext).Assembly);
        }

        public DbSet<JobTask> JobTasks { get; set; }
        public DbSet<Backup> Backups { get; set; }
    }
}
