using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;

namespace Wage.Data.Configurations
{
    public class GroupManagerScheduleConfiguration : IEntityTypeConfiguration<GroupManagerSchedule>
    {
        public GroupManagerScheduleConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupManagerSchedule>()
                .HasData(new GroupManagerSchedule
                {
                    Id = 1,
                    EntranceDate = "1399/01/01",
                    EntranceTime = "08:00",
                    ExitTime = "12:00",
                    MinTime = "09:00",
                    IsOnline=true ,
                    GroupManagerId = 1
                },
                new GroupManagerSchedule
                {
                    Id = 2,
                    EntranceDate = "1399/01/02",
                    EntranceTime = "08:00",
                    ExitTime = "16:00",
                    MinTime = "08:00",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 3,
                    EntranceDate = "1399/01/03",
                    EntranceTime = "08:00",
                    ExitTime = "17:00",
                    MinTime = "09:00",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 4,
                    EntranceDate = "1399/01/04",
                    EntranceTime = "08:00",
                    ExitTime = "13:45",
                    MinTime = "05:45",
                    IsOnline = true,
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 5,
                    EntranceDate = "1399/01/05",
                    EntranceTime = "08:00",
                    ExitTime = "15:10",
                    MinTime = "07:10",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 6,
                    EntranceDate = "1399/01/06",
                    EntranceTime = "08:00",
                    ExitTime = "16:30",
                    MinTime = "08:30",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 7,
                    EntranceDate = "1399/01/07",
                    EntranceTime = "08:00",
                    ExitTime = "12:00",
                    MinTime = "04:00",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 8,
                    EntranceDate = "1399/01/08",
                    EntranceTime = "08:00",
                    ExitTime = "16:00",
                    MinTime = "08:00",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 9,
                    EntranceDate = "1399/01/09",
                    EntranceTime = "08:00",
                    ExitTime = "13:00",
                    MinTime = "05:00",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 10,
                    EntranceDate = "1399/01/10",
                    EntranceTime = "08:00",
                    ExitTime = "17:00",
                    MinTime = "09:00",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 11,
                    EntranceDate = "1399/01/11",
                    EntranceTime = "08:00",
                    ExitTime = "15:00",
                    MinTime = "07:00",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 12,
                    EntranceDate = "1399/01/12",
                    EntranceTime = "08:00",
                    ExitTime = "17:00",
                    MinTime = "09:00",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 13,
                    EntranceDate = "1399/01/13",
                    EntranceTime = "08:00",
                    ExitTime = "14:20",
                    MinTime = "06:20",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 14,
                    EntranceDate = "1399/01/14",
                    EntranceTime = "08:00",
                    ExitTime = "17:30",
                    MinTime = "09:30",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 15,
                    EntranceDate = "1399/01/15",
                    EntranceTime = "08:00",
                    ExitTime = "14:30",
                    MinTime = "06:30",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 16,
                    EntranceDate = "1399/01/16",
                    EntranceTime = "08:00",
                    ExitTime = "16:30",
                    MinTime = "08:00",
                    GroupManagerId = 1
                }
                , new GroupManagerSchedule
                {
                    Id = 17,
                    EntranceDate = "1399/01/17",
                    EntranceTime = "08:00",
                    ExitTime = "11:00",
                    MinTime = "03:00",
                    GroupManagerId = 1
                }
                //----------------
               , new GroupManagerSchedule
               {
                   Id = 18,
                   EntranceDate = "1399/01/01",
                   EntranceTime = "08:00",
                   ExitTime = "17:00",
                   MinTime = "09:00",
                   GroupManagerId = 2
               }
                , new GroupManagerSchedule
                {
                    Id = 19,
                    EntranceDate = "1399/01/02",
                    EntranceTime = "08:00",
                    ExitTime = "16:00",
                    MinTime = "08:00",
                    IsOnline = true,
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 20,
                    EntranceDate = "1399/01/03",
                    EntranceTime = "08:00",
                    ExitTime = "17:00",
                    MinTime = "09:00",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 21,
                    EntranceDate = "1399/01/04",
                    EntranceTime = "08:00",
                    ExitTime = "13:45",
                    MinTime = "05:45",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 22,
                    EntranceDate = "1399/01/05",
                    EntranceTime = "08:00",
                    ExitTime = "15:10",
                    MinTime = "07:10",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 23,
                    EntranceDate = "1399/01/06",
                    EntranceTime = "08:00",
                    ExitTime = "16:30",
                    IsOnline = true,
                    MinTime = "08:30",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 24,
                    EntranceDate = "1399/01/07",
                    EntranceTime = "08:00",
                    ExitTime = "12:00",
                    MinTime = "04:00",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 25,
                    EntranceDate = "1399/01/08",
                    EntranceTime = "08:00",
                    ExitTime = "16:00",
                    MinTime = "08:00",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 26,
                    EntranceDate = "1399/01/09",
                    EntranceTime = "08:00",
                    ExitTime = "13:00",
                    MinTime = "05:00",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 27,
                    EntranceDate = "1399/01/10",
                    EntranceTime = "08:00",
                    ExitTime = "17:00",
                    MinTime = "09:00",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 28,
                    EntranceDate = "1399/01/11",
                    EntranceTime = "08:00",
                    ExitTime = "15:00",
                    MinTime = "07:00",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 29,
                    EntranceDate = "1399/01/12",
                    EntranceTime = "08:00",
                    ExitTime = "17:00",
                    MinTime = "09:00",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 30,
                    EntranceDate = "1399/01/13",
                    EntranceTime = "08:00",
                    ExitTime = "14:20",
                    MinTime = "06:20",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 31,
                    EntranceDate = "1399/01/14",
                    EntranceTime = "08:00",
                    ExitTime = "17:30",
                    MinTime = "09:30",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 32,
                    EntranceDate = "1399/01/15",
                    EntranceTime = "08:00",
                    ExitTime = "14:30",
                    MinTime = "06:30",
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 33,
                    EntranceDate = "1399/01/16",
                    EntranceTime = "08:00",
                    ExitTime = "16:30",
                    MinTime = "08:00",
                    IsOnline = true,
                    GroupManagerId = 2
                }
                , new GroupManagerSchedule
                {
                    Id = 34,
                    EntranceDate = "1399/01/17",
                    EntranceTime = "08:00",
                    ExitTime = "11:00",
                    MinTime = "03:00",
                    GroupManagerId = 2
                }
               //----------------
               , new GroupManagerSchedule
               {
                   Id = 35,
                   EntranceDate = "1399/01/01",
                   EntranceTime = "08:00",
                   ExitTime = "17:00",
                   MinTime = "09:00",
                   GroupManagerId = 3
               }
                , new GroupManagerSchedule
                {
                    Id = 36,
                    EntranceDate = "1399/01/02",
                    EntranceTime = "08:00",
                    ExitTime = "16:00",
                    IsOnline = true,
                    MinTime = "08:00",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 37,
                    EntranceDate = "1399/01/03",
                    EntranceTime = "08:00",
                    ExitTime = "17:00",
                    MinTime = "09:00",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 38,
                    EntranceDate = "1399/01/04",
                    EntranceTime = "08:00",
                    ExitTime = "13:45",
                    MinTime = "05:45",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 39,
                    EntranceDate = "1399/01/05",
                    EntranceTime = "08:00",
                    IsOnline = true,
                    ExitTime = "15:10",
                    MinTime = "07:10",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 40,
                    EntranceDate = "1399/01/06",
                    EntranceTime = "08:00",
                    ExitTime = "16:30",
                    MinTime = "08:30",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 41,
                    EntranceDate = "1399/01/07",
                    EntranceTime = "08:00",
                    ExitTime = "12:00",
                    MinTime = "04:00",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 42,
                    EntranceDate = "1399/01/08",
                    EntranceTime = "08:00",
                    ExitTime = "16:00",
                    MinTime = "08:00",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 43,
                    EntranceDate = "1399/01/09",
                    EntranceTime = "08:00",
                    IsOnline = true,
                    ExitTime = "13:00",
                    MinTime = "05:00",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 44,
                    EntranceDate = "1399/01/10",
                    EntranceTime = "08:00",
                    ExitTime = "17:00",
                    MinTime = "09:00",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 45,
                    EntranceDate = "1399/01/11",
                    EntranceTime = "08:00",
                    ExitTime = "15:00",
                    MinTime = "07:00",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 46,
                    EntranceDate = "1399/01/12",
                    EntranceTime = "08:00",
                    ExitTime = "17:00",
                    MinTime = "09:00",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 47,
                    EntranceDate = "1399/01/13",
                    EntranceTime = "08:00",
                    ExitTime = "14:20",
                    MinTime = "06:20",
                    IsOnline = true,
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 48,
                    EntranceDate = "1399/01/14",
                    EntranceTime = "08:00",
                    ExitTime = "17:30",
                    MinTime = "09:30",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 49,
                    EntranceDate = "1399/01/15",
                    EntranceTime = "08:00",
                    ExitTime = "14:30",
                    MinTime = "06:30",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 50,
                    EntranceDate = "1399/01/16",
                    EntranceTime = "08:00",
                    ExitTime = "16:30",
                    MinTime = "08:00",
                    GroupManagerId = 3
                }
                , new GroupManagerSchedule
                {
                    Id = 51,
                    EntranceDate = "1399/01/17",
                    EntranceTime = "08:00",
                    ExitTime = "11:00",
                    MinTime = "03:00",
                    GroupManagerId = 3
                });
        }


        public void Configure(EntityTypeBuilder<GroupManagerSchedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Id).HasColumnType("decimal(18,0)");

            builder.Property(x => x.EntranceDate).HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.EntranceTime).HasColumnType("nvarchar(5)").IsRequired();
            builder.Property(x => x.ExitTime).HasColumnType("nvarchar(5)").IsRequired();
            builder.Property(x => x.MinTime).HasColumnType("nvarchar(5)").IsRequired();
            builder.Property(x => x.GroupManagerId).HasColumnType("decimal(18,0)").IsRequired();
            builder.Property(x => x.IsOnline).HasColumnType("bit").HasDefaultValueSql("((0))").IsRequired();
            builder.Property(x => x.Active).IsRequired().HasColumnType("bit").HasDefaultValueSql("((1))");
        }
    }
}
