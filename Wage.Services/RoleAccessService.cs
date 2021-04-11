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
    public class RoleAccessService : IRoleAccessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleAccessService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual async Task<RoleAccess> AddRoleAccessAsync(RoleAccess item)
        {
            var roleAccess = await _unitOfWork.RoleAccesses.EditAsync(item);
            await _unitOfWork.CommitAsync();
            return roleAccess;
        }

        public virtual async Task<RoleAccess> EditRoleAccessAsync(RoleAccess item)
        {
            var roleAccess = await _unitOfWork.RoleAccesses.EditAsync(item);
            await _unitOfWork.CommitAsync();
            return roleAccess;
        }

        public virtual async Task<bool> RemoveRoleAccessAsync(RoleAccess item)
        {
            var res = await _unitOfWork.RoleAccesses.RemoveAsync(item);
            await _unitOfWork.CommitAsync();
            return res;
        }


        public virtual async Task<RoleAccess> FindOneAsync(Expression<Func<RoleAccess, bool>> whereClause)
        {
            var item = await _unitOfWork.RoleAccesses.FindOneAsync(whereClause);
            return item;
        }

        public virtual async Task<IEnumerable<RoleAccess>> GetAllRoleAccessAsync()
        {
            var list = await _unitOfWork.RoleAccesses.GetAllAsync();
            return list;
        }

        public virtual async Task<IEnumerable<RoleAccess>> GetManyRoleAccessAsync(Expression<Func<RoleAccess, bool>> whereClause)
        {
            var list = await _unitOfWork.RoleAccesses.GetManyAsync(whereClause);
            return list; 
        }

        public virtual async Task<RoleAccess> GetRoleAccessByIdAsync(object id)
        {
            var item = await _unitOfWork.RoleAccesses.GetByIdAsync(id);
            return item;
        }

        public virtual async Task<bool> IsExists(object id)
        {
            var res = await _unitOfWork.RoleAccesses.IsExists(id);
            return res;
        }

        public virtual async Task<bool> IsExists(Expression<Func<RoleAccess, bool>> whereClause)
        {
            var res = await _unitOfWork.RoleAccesses.IsExists(whereClause);
            return res;
        }

        

        
    }
}
