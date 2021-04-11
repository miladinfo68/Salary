using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IServices
{
    public interface IGroupManagerService
    {
        Task<GroupManager> GetGroupManagerById(object id);
        Task<GroupManager> FindOneAsync(Expression<Func<GroupManager, bool>> whereClause);
        Task<IEnumerable<GroupManager>> GetAllGroupManagers(string year = "0", string month = "0", string startAt = "0");
        Task<IEnumerable<GroupManager>> GetManyGroupManagers(Expression<Func<GroupManager, bool>> whereClause);
        Task<bool> EditGroupManagerInfo(GroupManager item);

        //Task<IEnumerable<GroupManager>> GetAllEntranceInfoAsync();

        Task<List<GroupManager>> GetByFilterAsync(params Expression<Func<GroupManager, bool>>[] filters);
        
    }
}
