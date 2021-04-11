using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IServices
{
    public interface IRoleService
    {
        Task<Role> GetRoleByIdAsync(object id);
        Task<Role> FindOneAsync(Expression<Func<Role, bool>> whereClause);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<IEnumerable<Role>> GetManyRolesAsync(Expression<Func<Role, bool>> whereClause);
        Task<Role> AddRoleAsync(Role item);
        Task<Role> EditRoleAsync(Role item);
        Task<bool> RemoveRoleAsync(Role item);
        Task<bool> RemoveRoleAsync(object id);
        Task<bool> IsExists(object id);
        Task<bool> IsExists(Expression<Func<Role, bool>> whereClause);
    }
}
