using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;

namespace Wage.Data.Configurations
{
    public class AccessLinkConfiguration : IEntityTypeConfiguration<AccessLink>
    {
        public AccessLinkConfiguration(ModelBuilder modelBuilder)
        {            
        }
        public void Configure(EntityTypeBuilder<AccessLink> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnType("decimal(18,0)");
            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.Area).HasColumnType("nvarchar(100)");
            builder.Property(m => m.Controller).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(m => m.Action).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(m => m.Active).IsRequired().HasColumnType("bit").HasDefaultValueSql("((1))");

        }
    }
}

