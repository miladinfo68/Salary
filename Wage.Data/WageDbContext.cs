using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wage.Core.Entities;
using Wage.Data.Configurations;

namespace Wage.Data
{
    public class WageDbContext: DbContext//IdentityDbContext<User, Role, Guid>
    {
        public DbSet<GroupManager> GroupManagers { get; set; }
        public DbSet<GroupManagerSchedule> GroupManagerSchedules{ get; set; }
        public DbSet<GroupManagerDetails> GroupManagerDetails { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccessLink> AccessLinks { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }        
        public DbSet<RoleAccess> RoleAccesses { get; set; }

        public WageDbContext(DbContextOptions<WageDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new GroupManagerConfiguration(builder));
            builder.ApplyConfiguration(new GroupManagerDetailesConfiguration(builder));
            builder.ApplyConfiguration(new GroupManagerScheduleConfiguration(builder));

            builder.ApplyConfiguration(new HolidayConfiguration(builder));

            builder.ApplyConfiguration(new UserConfiguration(builder));
            builder.ApplyConfiguration(new RoleConfiguration(builder));
            builder.ApplyConfiguration(new AccessLinkConfiguration(builder));

            builder.ApplyConfiguration(new UserRolesConfiguration(builder));
            builder.ApplyConfiguration(new RoleAccessConfiguration(builder));
        }

    }
}
