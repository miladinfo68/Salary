using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;

namespace Wage.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public UserConfiguration(ModelBuilder modelBuilder)
        {
            //pass=123   ====>hash=GEwa01iaRNvdbsOGhIFi4w==
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,                 
                 Username="milad@gmail.com",
                 FirstName="میلاد",
                 LastName="جلالی",
                 Password="GEwa01iaRNvdbsOGhIFi4w==",               
            }
            , new User
            {
                Id = 2,                
                Username = "feri@gmail.com",
                FirstName = "فربد",
                LastName = "ساسانی",
                Password = "GEwa01iaRNvdbsOGhIFi4w==",
               
            }
             , new User
             {
                 Id = 3,                 
                 Username = "reza@gmail.com",
                 FirstName = "رضا",
                 LastName = "عطاران",
                 Password = "GEwa01iaRNvdbsOGhIFi4w==",
                
             });

        }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnType("decimal(18,0)");
            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.Username).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(m => m.FirstName).HasColumnType("nvarchar(max)");
            builder.Property(m => m.LastName).HasColumnType("nvarchar(max)");
            builder.Property(m => m.Password).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(m => m.Token).HasColumnType("nvarchar(max)");
            builder.Property(m => m.TokenExpireTime).HasColumnType("DateTime");
            builder.Property(m => m.Active).IsRequired().HasColumnType("bit").HasDefaultValueSql("((1))");            
        }
    }
}
