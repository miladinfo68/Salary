using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IServices
{
    public interface IRoleAccessService
    {
        Task<RoleAccess> GetRoleAccessByIdAsync(object id);
        Task<RoleAccess> FindOneAsync(Expression<Func<RoleAccess, bool>> whereClause);
        Task<IEnumerable<RoleAccess>> GetAllRoleAccessAsync();
        Task<IEnumerable<RoleAccess>> GetManyRoleAccessAsync(Expression<Func<RoleAccess, bool>> whereClause);
        Task<RoleAccess> AddRoleAccessAsync(RoleAccess item);
        Task<RoleAccess> EditRoleAccessAsync(RoleAccess item);
        Task<bool> RemoveRoleAccessAsync(RoleAccess item);
        Task<bool> IsExists(object id);
        Task<bool> IsExists(Expression<Func<RoleAccess, bool>> whereClause);
    }
}
