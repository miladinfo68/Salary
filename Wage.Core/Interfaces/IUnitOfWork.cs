using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Interfaces.IRepositories;

namespace Wage.Core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGroupManagerRepository GroupManagers { get;}
        IGroupManagerScheduleRepository GroupManagerSchedules { get; }
        IGroupManagerDetailesRepository GroupManagerDetailes { get; }
        IHolidayRepository Holidays { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IAccessLinkRepository AccessLinks { get; }
        IUserRoleRepository UserRoles { get; }
        IRoleAccessRepository RoleAccesses { get; }
        Task<int> CommitAsync();
    }
}
