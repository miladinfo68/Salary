using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Interfaces;
using Wage.Core.Interfaces.IRepositories;
using Wage.Data.Repositories;


namespace Wage.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WageDbContext _context;

        private GroupManagerRepository _groupManagerRepository;
        private GroupManagerDetailesRepository _groupManagerDetailesRepository;
        private GroupManagerScheduleRepository _roupManagerScheduleRepository;
        private HolidayRepository _holidayRepository;
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
        private AccessLinkRepository _accessLinkRepository;
        private UserRoleRepository _userRolesRepository;
        private RoleAccessRepository _roleAccessRepository;


        public UnitOfWork(WageDbContext context)
        {
            this._context = context;
        }


        public IGroupManagerRepository GroupManagers =>
            _groupManagerRepository == null
            ? new GroupManagerRepository(_context)
            : _groupManagerRepository;

        public IGroupManagerScheduleRepository GroupManagerSchedules =>
           _roupManagerScheduleRepository == null
           ? new GroupManagerScheduleRepository(_context)
           : _roupManagerScheduleRepository;

        public IGroupManagerDetailesRepository GroupManagerDetailes =>
           _groupManagerDetailesRepository == null
            ? new GroupManagerDetailesRepository(_context)
            : _groupManagerDetailesRepository;

        public IHolidayRepository Holidays =>
           _holidayRepository == null
           ? new HolidayRepository(_context)
           : _holidayRepository;

        public IUserRepository Users =>
          _userRepository == null
          ? new UserRepository(_context)
          : _userRepository;

        public IRoleRepository Roles =>
          _roleRepository == null
          ? new RoleRepository(_context)
          : _roleRepository;

        public IAccessLinkRepository AccessLinks =>
          _accessLinkRepository == null
          ? new AccessLinkRepository(_context)
          : _accessLinkRepository;

        public IUserRoleRepository UserRoles =>
          _userRolesRepository == null
          ? new UserRoleRepository(_context)
          : _userRolesRepository;

        public IRoleAccessRepository RoleAccesses =>
          _roleAccessRepository == null
          ? new RoleAccessRepository(_context)
          : _roleAccessRepository;



        public virtual async Task<int> CommitAsync()
        {
            var res = 0;
            try
            {
                res = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return res;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
