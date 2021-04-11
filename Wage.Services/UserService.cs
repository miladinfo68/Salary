using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;
using Wage.Core.Interfaces;
using Wage.Core.Interfaces.IServices;

namespace Wage.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual async Task<User> AddUserAsync(User item)
        {
            var user = await _unitOfWork.Users.AddAsync(item);
            await _unitOfWork.CommitAsync();        
            return user;
        }

        public virtual async Task<User> EditUserAsync(User item)
        {
            var user = await _unitOfWork.Users.EditAsync(item);
            await _unitOfWork.CommitAsync();
            return user;
        }
        public virtual async Task<bool> RemoveUserAsync(User item)
        {
            var res = await _unitOfWork.Users.RemoveAsync(item);
            await _unitOfWork.CommitAsync();
            return res;
        }

        public virtual async Task<bool> RemoveUserAsync(object id)
        {
            var res = await _unitOfWork.Users.RemoveByIdAsync(id);
            await _unitOfWork.CommitAsync();
            return res;
        }
        public virtual async Task<User> FindOneAsync(Expression<Func<User, bool>> whereClause)
        {
            var item = await _unitOfWork.Users.FindOneAsync(whereClause);
            return item;
        }

        public virtual async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var list = await _unitOfWork.Users.GetAllAsync();
            return list;
        }

        public virtual async Task<IEnumerable<User>> GetManyUsersAsync(Expression<Func<User, bool>> whereClause)
        {
            var list = await _unitOfWork.Users.GetManyAsync(whereClause);
            return list; 
        }

        public virtual async Task<User> GetUserByIdAsync(object id)
        {
            var item = await _unitOfWork.Users.GetByIdAsync(id);
            return item;
        }

        public virtual async Task<bool> IsExists(object id)
        {
            var res = await _unitOfWork.Users.IsExists(id);
            return res;
        }

        public virtual async Task<bool> IsExists(Expression<Func<User, bool>> whereClause)
        {
            var res = await _unitOfWork.Users.IsExists(whereClause);
            return res;
        }

        

    }
}
