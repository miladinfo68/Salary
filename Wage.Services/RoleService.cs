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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual async Task<Role> AddRoleAsync(Role item)
        {
            var role = await _unitOfWork.Roles.EditAsync(item);
            await _unitOfWork.CommitAsync();
            return role;
        }

        public virtual async Task<Role> EditRoleAsync(Role item)
        {
            var role = await _unitOfWork.Roles.EditAsync(item);
            await _unitOfWork.CommitAsync();
            return role;
        }

        public virtual async Task<Role> FindOneAsync(Expression<Func<Role, bool>> whereClause)
        {
            var item = await _unitOfWork.Roles.FindOneAsync(whereClause);
            return item;
        }

        public virtual async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            var list = await _unitOfWork.Roles.GetAllAsync();
            return list;
        }

        public virtual async Task<IEnumerable<Role>> GetManyRolesAsync(Expression<Func<Role, bool>> whereClause)
        {
            var list = await _unitOfWork.Roles.GetManyAsync(whereClause);
            return list; 
        }

        public virtual async Task<Role> GetRoleByIdAsync(object id)
        {
            var item = await _unitOfWork.Roles.GetByIdAsync(id);
            return item;
        }

        public virtual async Task<bool> IsExists(object id)
        {
            var res = await _unitOfWork.Roles.IsExists(id);
            return res;
        }

        public virtual async Task<bool> IsExists(Expression<Func<Role, bool>> whereClause)
        {
            var res = await _unitOfWork.Roles.IsExists(whereClause);
            return res;
        }

        public virtual async Task<bool> RemoveRoleAsync(Role item)
        {
            var res = await _unitOfWork.Roles.RemoveAsync(item);
            await _unitOfWork.CommitAsync();
            return res;
        }

        public virtual async Task<bool> RemoveRoleAsync(object id)
        {
            var res = await _unitOfWork.Roles.RemoveByIdAsync(id);
            await _unitOfWork.CommitAsync();
            return res;
        }

    }
}
