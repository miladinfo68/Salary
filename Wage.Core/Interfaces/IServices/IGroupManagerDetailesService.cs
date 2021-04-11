using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IServices
{
    public interface IGroupManagerDetailesService
    {
        Task<IEnumerable<GroupManagerDetails>> GetAllGroupManagerDetails();
        Task<IEnumerable<GroupManagerDetails>> GetManyGroupManagerDetails(Expression<Func<GroupManagerDetails, bool>> whereClause);
        Task<bool> AddNewGroupManagerDetails(GroupManagerDetails item);
        Task<bool> RemoveGroupManagerDetails(object id);
        //Task<bool> IsExists(GroupManagerDetails item);
    }
}
