using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;

namespace Wage.Data.Configurations
{
    public class GroupManagerDetailesConfiguration : IEntityTypeConfiguration<GroupManagerDetails>
    {
        public GroupManagerDetailesConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupManagerDetails>()
                .HasData(new GroupManagerDetails
                {
                    Id = 1,
                    EntranceDate = "1399/01/01",
                    EntranceTime = "06:00",
                    ExitTime = "19:30",
                    IsOnline = false,
                    GroupManagerId = 1
                },
                new GroupManagerDetails
                {
                    Id = 2,
                    EntranceDate = "1399/01/02",
                    EntranceTime = "08:00",
                    ExitTime = "15:00",
                    IsOnline = false,
                    GroupManagerId = 1
                },
                new GroupManagerDetails
                {
                    Id = 3,
                    EntranceDate = "1399/01/03",
                    EntranceTime = "08:00",
                    ExitTime = "10:00",
                    IsOnline = true,
                    GroupManagerId = 1
                },
                new GroupManagerDetails
                {
                    Id = 4,
                    EntranceDate = "1399/01/04",
                    EntranceTime = "06:40",
                    ExitTime = "10:00",
                    IsOnline = false,
                    GroupManagerId = 1
                },
                new GroupManagerDetails
                {
                    Id = 5,
                    EntranceDate = "1399/01/01",
                    EntranceTime = "08:00",
                    ExitTime = "10:00",
                    IsOnline = false,
                    GroupManagerId = 2
                },
                new GroupManagerDetails
                {
                    Id = 6,
                    EntranceDate = "1399/01/02",
                    EntranceTime = "09:00",
                    ExitTime = "09:30",
                    IsOnline = false,
                    GroupManagerId = 2
                },
                new GroupManagerDetails
                {
                    Id = 7,
                    EntranceDate = "1399/01/03",
                    EntranceTime = "08:30",
                    ExitTime = "14:50",
                    IsOnline = true,
                    GroupManagerId = 2
                },
                new GroupManagerDetails
                {
                    Id = 8,
                    EntranceDate = "1399/01/01",
                    EntranceTime = "08:00",
                    ExitTime = "11:00",
                    IsOnline = true,
                    GroupManagerId = 3
                }
                ,
                new GroupManagerDetails
                {
                    Id = 9,
                    EntranceDate = "1399/01/02",
                    EntranceTime = "08:00",
                    ExitTime = "11:00",
                    IsOnline = false,
                    GroupManagerId = 3
                }
                ,
                new GroupManagerDetails
                {
                    Id = 10,
                    EntranceDate = "1399/01/04",
                    EntranceTime = "09:00",
                    ExitTime = "09:30",
                    IsOnline = false,
                    GroupManagerId = 3
                }
                , new GroupManagerDetails
                {
                    Id = 11,
                    EntranceDate = "1399/01/08",
                    EntranceTime = "08:00",
                    ExitTime = "10:00",
                    IsOnline = false,
                    GroupManagerId = 1
                },
                new GroupManagerDetails
                {
                    Id = 12,
                    EntranceDate = "1399/01/09",
                    EntranceTime = "08:00",
                    ExitTime = "15:00",
                    IsOnline = false,
                    GroupManagerId = 1
                },
                new GroupManagerDetails
                {
                    Id = 13,
                    EntranceDate = "1399/01/10",
                    EntranceTime = "08:00",
                    ExitTime = "10:00",
                    IsOnline = true,
                    GroupManagerId = 1
                },
                new GroupManagerDetails
                {
                    Id = 14,
                    EntranceDate = "1399/01/14",
                    EntranceTime = "08:00",
                    ExitTime = "10:00",
                    IsOnline = false,
                    GroupManagerId = 1
                },
                new GroupManagerDetails
                {
                    Id = 15,
                    EntranceDate = "1399/01/08",
                    EntranceTime = "08:00",
                    ExitTime = "10:00",
                    IsOnline = false,
                    GroupManagerId = 2
                },
                new GroupManagerDetails
                {
                    Id = 16,
                    EntranceDate = "1399/01/09",
                    EntranceTime = "08:00",
                    ExitTime = "11:30",
                    IsOnline = false,
                    GroupManagerId = 2
                },
                new GroupManagerDetails
                {
                    Id = 17,
                    EntranceDate = "1399/01/10",
                    EntranceTime = "08:30",
                    ExitTime = "14:50",
                    IsOnline = true,
                    GroupManagerId = 2
                },
                new GroupManagerDetails
                {
                    Id = 18,
                    EntranceDate = "1399/01/08",
                    EntranceTime = "08:00",
                    ExitTime = "11:00",
                    IsOnline = true,
                    GroupManagerId = 3
                }
                ,
                new GroupManagerDetails
                {
                    Id = 19,
                    EntranceDate = "1399/01/09",
                    EntranceTime = "08:00",
                    ExitTime = "11:00",
                    IsOnline = false,
                    GroupManagerId = 3
                }
                ,
                new GroupManagerDetails
                {
                    Id = 20,
                    EntranceDate = "1399/01/10",
                    EntranceTime = "09:00",
                    ExitTime = "11:00",
                    IsOnline = false,
                    GroupManagerId = 3
                });
        }
        public void Configure(EntityTypeBuilder<GroupManagerDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x => x.Id).HasColumnType("decimal(18,0)");

            builder.Property(x => x.EntranceDate).HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.EntranceTime).HasColumnType("nvarchar(5)").IsRequired();
            builder.Property(x => x.ExitTime).HasColumnType("nvarchar(5)").IsRequired();
            builder.Property(x => x.IsOnline).HasColumnType("bit").HasDefaultValueSql("((0))").IsRequired();
            builder.Property(x => x.GroupManagerId).HasColumnType("decimal(18,0)").IsRequired();
            builder.Property(x => x.Active).IsRequired().HasColumnType("bit").HasDefaultValueSql("((1))");
            //builder
            //    .HasOne<GroupManager>(m => m.GroupManager)
            //    .WithMany(a => a.GroupManagerDetails)
            //    .HasForeignKey(m => m.GroupManagerId);
        }
    }
}
