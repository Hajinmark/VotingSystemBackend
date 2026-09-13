using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Persistence.Configurations
{
    public class UserElectionConfiguration : IEntityTypeConfiguration<UserElection>
    {
        public void Configure(EntityTypeBuilder<UserElection> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserElections)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Election)
                .WithMany(x => x.UserElections)
                .HasForeignKey(x => x.ElectionId);
        }
    }
}
