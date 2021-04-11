using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IServices
{
    public interface IAccessLinkService
    {
        Task<AccessLink> GetAccessLinkByIdAsync(object id);
        Task<AccessLink> FindOneAsync(Expression<Func<AccessLink, bool>> whereClause);
        Task<IEnumerable<AccessLink>> GetAllAccessLinksAsync();
        Task<IEnumerable<AccessLink>> GetManyAccessLinksAsync(Expression<Func<AccessLink, bool>> whereClause);
        Task<AccessLink> AddAccessLinkAsync(AccessLink item);
        Task<AccessLink> EditAccessLinkAsync(AccessLink item);
        Task<bool> RemoveAccessLinkAsync(AccessLink item);
        Task<bool> IsExists(object id);
        Task<bool> IsExists(Expression<Func<AccessLink, bool>> whereClause);
    }
}
