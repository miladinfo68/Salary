using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;

namespace Wage.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public RoleConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                RoleName = "Admin",
                DisplayName = "کاربر ارشد",                
            }
            , new Role
            {
                Id = 2,
                RoleName = "User",
                DisplayName = "کاربر",
            });

        }
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnType("decimal(18,0)");
            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.RoleName).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(m => m.DisplayName).HasColumnType("nvarchar(100)");
            builder.Property(m => m.Active).IsRequired().HasColumnType("bit").HasDefaultValueSql("((1))");

        }
    }
}

