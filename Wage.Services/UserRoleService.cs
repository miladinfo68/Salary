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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRoleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual async Task<UserRole> AddUserRoleAsync(UserRole item)
        {
            var role = await _unitOfWork.UserRoles.EditAsync(item);
            await _unitOfWork.CommitAsync();
            return role;
        }

        public virtual async Task<UserRole> EditUserRoleAsync(UserRole item)
        {
            var role = await _unitOfWork.UserRoles.EditAsync(item);
            await _unitOfWork.CommitAsync();
            return role;
        }

        public virtual async Task<UserRole> FindOneAsync(Expression<Func<UserRole, bool>> whereClause)
        {
            var item = await _unitOfWork.UserRoles.FindOneAsync(whereClause);
            return item;
        }

        public virtual async Task<IEnumerable<UserRole>> GetAllUserRolesAsync()
        {
            var list = await _unitOfWork.UserRoles.GetAllAsync();
            return list;
        }

        public virtual async Task<IEnumerable<UserRole>> GetManyUserRolesAsync(Expression<Func<UserRole, bool>> whereClause)
        {
            var list = await _unitOfWork.UserRoles.GetManyAsync(whereClause);
            return list; 
        }

        public virtual async Task<UserRole> GetUserRoleByIdAsync(object id)
        {
            var item = await _unitOfWork.UserRoles.GetByIdAsync(id);
            return item;
        }

        public virtual async Task<bool> IsExists(object id)
        {
            var res = await _unitOfWork.UserRoles.IsExists(id);
            return res;
        }

        public virtual async Task<bool> IsExists(Expression<Func<UserRole, bool>> whereClause)
        {
            var res = await _unitOfWork.UserRoles.IsExists(whereClause);
            return res;
        }

        public virtual async Task RemoveRangeUserRoleAsync(IEnumerable<UserRole> entities)
        {
            await _unitOfWork.UserRoles.RemoveRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public virtual async Task AddRangeUserRoleAsync(IEnumerable<UserRole> entities)
        {
            await _unitOfWork.UserRoles.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public virtual async Task<bool> RemoveUserRoleAsync(UserRole item)
        {
            var res = await _unitOfWork.UserRoles.RemoveAsync(item);
            await _unitOfWork.CommitAsync();
            return res;
        }

    }
}
