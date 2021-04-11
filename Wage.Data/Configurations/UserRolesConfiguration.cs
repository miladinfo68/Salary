using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;

namespace Wage.Data.Configurations
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public UserRolesConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = 1,
                UserId=1,
                RoleId=1
            }
            , new UserRole
            {
                Id = 2,
                UserId = 2,
                RoleId = 2
            }
            //,new UserRole
            //{
            //    Id = 3,
            //    UserId = 2,
            //    RoleId = 3
            //}
            //,new UserRole
            //{
            //    Id = 4,
            //    UserId = 3,
            //    RoleId = 3
            //}
            //,new UserRole
            //{
            //    Id = 5,
            //    UserId = 4,
            //    RoleId = 5
            //}
            //,new UserRole
            //{
            //    Id = 6,
            //    UserId = 5,
            //    RoleId = 4
            //}
            //,new UserRole
            //{
            //    Id = 7,
            //    UserId = 6,
            //    RoleId = 6
            //}
            //, new UserRole
            //{
            //    Id = 8,
            //    UserId = 7,
            //    RoleId = 6
            //}
            //, new UserRole
            //{
            //    Id = 9,
            //    UserId = 8,
            //    RoleId = 7
            //}
            //, new UserRole
            //{
            //    Id = 10,
            //    UserId = 9,
            //    RoleId = 8
            //}
            );

        }
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnType("decimal(18,0)");
            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.UserId).HasColumnType("decimal(18,0)");
            builder.Property(m => m.RoleId).HasColumnType("decimal(18,0)");
            builder.Property(m => m.Active).IsRequired().HasColumnType("bit").HasDefaultValueSql("((1))");


            
        }
    }
}
