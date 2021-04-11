using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;

namespace Wage.Data.Configurations
{
    public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public HolidayConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Holiday>().HasData(new Holiday

            {
                Id = 1,
                HolidayDate = "1399/01/12",
                Note = "روز ج.ا"
            }
             , new Holiday
             {
                 Id = 2,
                 HolidayDate = "1399/01/13",
                 Note = "روز درختکاری"
             }
             , new Holiday
             {
                 Id = 3,
                 HolidayDate = "1399/01/25",
                 Note = "ولادت حضرت علی"
             }
             , new Holiday
             {
                 Id = 4,
                 HolidayDate = "1399/07/03",
                 Note = "آلودگی هوا"
             }
             , new Holiday
             {
                 Id = 5,
                 HolidayDate = "1399/07/03",
                 Note = "آلودگی هوا"
             }
            , new Holiday
            {
                Id = 6,
                HolidayDate = "1399/07/10",
                Note = "آلودگی هوا"
            }
            , new Holiday
            {
                Id =7,
                HolidayDate = "1399/07/27",
                Note = "آلودگی هوا"
            }
            , new Holiday
            {
                Id = 8,
                HolidayDate = "1399/08/01",
                Note = "برف سنگین"
            }
            , new Holiday
            {
                Id = 9,
                HolidayDate = "1399/08/19",
                Note = "سقوط هواپیما"
            }
            , new Holiday
            {
                Id = 10,
                HolidayDate = "1399/09/12",
                Note = "برف سنگین"
            }
            , new Holiday
            {
                Id = 11,
                HolidayDate = "1399/09/13",
                Note = "برف سنگین"
            }
            , new Holiday
            {
                Id = 12,
                HolidayDate = "1399/10/18",
                Note = "آلودگی هوا"
            }
            , new Holiday
            {
                Id = 13,
                HolidayDate = "1399/11/11",
                Note = "آلودگی هوا"
            }
            , new Holiday
            {
                Id = 14,
                HolidayDate = "1399/12/12",
                Note = "آلودگی هوا"
            });

        }
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnType("decimal(18,0)");
            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.HolidayDate).IsRequired().HasColumnType("nvarchar(10)");
            builder.Property(m => m.Note).HasColumnType("nvarchar(max)");
            builder.Property(m => m.Active).IsRequired().HasColumnType("bit").HasDefaultValueSql("((1))");
        }
    }
}
