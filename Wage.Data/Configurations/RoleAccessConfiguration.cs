using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;

namespace Wage.Data.Configurations
{
    public class RoleAccessConfiguration : IEntityTypeConfiguration<RoleAccess>
    {
        public RoleAccessConfiguration(ModelBuilder modelBuilder)
        {            
        }
        public void Configure(EntityTypeBuilder<RoleAccess> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnType("decimal(18,0)");
            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.RoleId).HasColumnType("decimal(18,0)");
            builder.Property(m => m.AccessLinkId).HasColumnType("decimal(18,0)");
            builder.Property(m => m.Active).IsRequired().HasColumnType("bit").HasDefaultValueSql("((1))");

        }
    }
}

