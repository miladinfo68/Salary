using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;

namespace Wage.Data.Configurations
{
    public class GroupManagerConfiguration : IEntityTypeConfiguration<GroupManager>
    {
        public GroupManagerConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupManager>().HasData(new GroupManager
            {
                Id = 1,
                ProfCode = "10",
                ProfName = "فربد ساسانی",
                BaseAmount = "1000000",
                Year = "1399",
                Month = "01",
                StartAt = "1399/01/01",
                ChkCouncil = false,
                CouncilDate = null
            }
            , new GroupManager
            {
                Id = 2,
                ProfCode = "11",
                ProfName = "مهدی جلالی",
                BaseAmount = "800000",
                Year = "1399",
                Month = "01",
                StartAt = "1399/01/01",
                ChkCouncil = false,
                CouncilDate = null
            }
           
            , new GroupManager
            {
                Id = 3,
                ProfCode = "12",
                ProfName = "محمد سرگزی",
                BaseAmount = "500000",
                Year = "1399",
                Month = "01",
                StartAt = "1399/01/01",
                ChkCouncil = false,
                CouncilDate = null
            }
            //------------------
            , new GroupManager
            {
                Id = 4,
                ProfCode = "10",
                ProfName = "فربد ساسانی",
                BaseAmount = "20000",
                Year = "1399",
                Month = "02",
                StartAt = "1399/02/01",
                ChkCouncil = false,
                CouncilDate = null
            }
            , new GroupManager
            {
                Id = 5,
                ProfCode = "11",
                ProfName = "مهدی جلالی",
                BaseAmount = "5000",
                Year = "1399",
                Month = "02",
                StartAt = "1399/02/01",
                ChkCouncil = false,
                CouncilDate = null
            }
           
            , new GroupManager
            {
                Id = 6,
                ProfCode = "12",
                ProfName = "محمد سرگزی",
                BaseAmount = "70000",
                Year = "1399",
                Month = "02",
                StartAt = "1399/02/01",
                ChkCouncil = false,
                CouncilDate = null
            }
            //------------------
            , new GroupManager
            {
                Id = 7,
                ProfCode = "10",
                ProfName = "فربد ساسانی",
                BaseAmount = "1000000",
                Year = "1399",
                Month = "07",
                StartAt = "1399/07/01",
                ChkCouncil = false,
                CouncilDate = null
            }
            , new GroupManager
            {
                Id = 8,
                ProfCode = "11",
                ProfName = "مهدی جلالی",
                BaseAmount = "800000",
                Year = "1399",
                Month = "07",
                StartAt = "1399/07/01",
                ChkCouncil = false,
                CouncilDate = null
            }
            , new GroupManager
            {
                Id = 9,
                ProfCode = "12",
                ProfName = "محمد سرگزی",
                BaseAmount = "500000",
                Year = "1399",
                Month = "07",
                StartAt = "1399/07/01",
                ChkCouncil = false,
                CouncilDate = null
            }

            //------------------
            , new GroupManager
            {
                Id = 10,
                ProfCode = "10",
                ProfName = "فربد ساسانی",
                BaseAmount = "145266",
                Year = "1399",
                Month = "08",
                StartAt = "1399/08/01",
                ChkCouncil = false,
                CouncilDate = null
            }
            , new GroupManager
            {
                Id = 11,
                ProfCode = "11",
                ProfName = "مهدی جلالی",
                BaseAmount = "63000",
                Year = "1399",
                Month = "08",
                StartAt = "1399/08/01",
                ChkCouncil = false,
                CouncilDate = null
            }
            , new GroupManager
            {
                Id = 12,
                ProfCode = "12",
                ProfName = "محمد سرگزی",
                BaseAmount = "45000",
                Year = "1399",
                Month = "08",
                StartAt = "1399/08/01",
                ChkCouncil = false,
                CouncilDate = null
            });

        }
        public void Configure(EntityTypeBuilder<GroupManager> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnType("decimal(18,0)");
            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.ProfCode).IsRequired().HasColumnType("nvarchar(10)");
            builder.Property(m => m.ProfName).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(m => m.BaseAmount).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Year).HasMaxLength(4);
            builder.Property(m => m.Month).HasMaxLength(2);
            builder.Property(m => m.StartAt).HasMaxLength(10);
            builder.Property(m => m.ChkCouncil).IsRequired().HasColumnType("bit").HasDefaultValueSql("((0))");
            builder.Property(m => m.CouncilDate).HasColumnType("nvarchar(10)");
            builder.Property(m => m.Active).IsRequired().HasColumnType("bit").HasDefaultValueSql("((1))");

            //builder
            //    .HasMany<GroupManagerDetails>(m => m.GroupManagerDetails)
            //    .WithOne(a => a.GroupManager)
            //    .HasForeignKey(m => m.GroupManagerId);
        }
    }
}
