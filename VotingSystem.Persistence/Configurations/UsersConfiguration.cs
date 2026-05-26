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
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(p => p.Username)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(p => p.Username)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(p => p.Role)
                .IsRequired()
                .HasMaxLength(20);

        }
    }
}
