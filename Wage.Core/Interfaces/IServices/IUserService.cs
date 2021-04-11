using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(object id);
        Task<User> FindOneAsync(Expression<Func<User, bool>> whereClause);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<User>> GetManyUsersAsync(Expression<Func<User, bool>> whereClause);
        Task<User> AddUserAsync(User item);
        Task<User> EditUserAsync(User item);
        Task<bool> RemoveUserAsync(User item);
        Task<bool> RemoveUserAsync(object id);       
        Task<bool> IsExists(object id);
        Task<bool> IsExists(Expression<Func<User, bool>> whereClause);
    }
}
