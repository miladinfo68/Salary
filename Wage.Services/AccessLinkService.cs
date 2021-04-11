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
    public class AccessLinkService : IAccessLinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccessLinkService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual async Task<AccessLink> AddAccessLinkAsync(AccessLink item)
        {
            var link = await _unitOfWork.AccessLinks.EditAsync(item);
            return link;
        }

        public virtual async Task<AccessLink> EditAccessLinkAsync(AccessLink item)
        {
            var link = await _unitOfWork.AccessLinks.EditAsync(item);
            return link;
        }

        public virtual async Task<bool> RemoveAccessLinkAsync(AccessLink item)
        {
            var res = await _unitOfWork.AccessLinks.RemoveAsync(item);
            return res;
        }
        public virtual async Task<AccessLink> FindOneAsync(Expression<Func<AccessLink, bool>> whereClause)
        {
            var item = await _unitOfWork.AccessLinks.FindOneAsync(whereClause);
            return item;
        }

        public virtual async Task<IEnumerable<AccessLink>> GetAllAccessLinksAsync()
        {
            var list = await _unitOfWork.AccessLinks.GetAllAsync();
            return list;
        }

        public virtual async Task<IEnumerable<AccessLink>> GetManyAccessLinksAsync(Expression<Func<AccessLink, bool>> whereClause)
        {
            var list = await _unitOfWork.AccessLinks.GetManyAsync(whereClause);
            return list; 
        }

        public virtual async Task<AccessLink> GetAccessLinkByIdAsync(object id)
        {
            var item = await _unitOfWork.AccessLinks.GetByIdAsync(id);
            return item;
        }

        public virtual async Task<bool> IsExists(object id)
        {
            var res = await _unitOfWork.AccessLinks.IsExists(id);
            return res;
        }

        public virtual async Task<bool> IsExists(Expression<Func<AccessLink, bool>> whereClause)
        {
            var res = await _unitOfWork.AccessLinks.IsExists(whereClause);
            return res;
        }

        

    }
}
