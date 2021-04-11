using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IServices
{
    public interface IUserRoleService
    {
        Task<UserRole> GetUserRoleByIdAsync(object id);
        Task<UserRole> FindOneAsync(Expression<Func<UserRole, bool>> whereClause);
        Task<IEnumerable<UserRole>> GetAllUserRolesAsync();
        Task<IEnumerable<UserRole>> GetManyUserRolesAsync(Expression<Func<UserRole, bool>> whereClause);
        Task<UserRole> AddUserRoleAsync(UserRole item);
        Task<UserRole> EditUserRoleAsync(UserRole item);
        Task<bool> RemoveUserRoleAsync(UserRole item);

        Task AddRangeUserRoleAsync(IEnumerable<UserRole> entities);
        Task RemoveRangeUserRoleAsync(IEnumerable<UserRole> entities);
        Task<bool> IsExists(object id);
        Task<bool> IsExists(Expression<Func<UserRole, bool>> whereClause);
    }
}
