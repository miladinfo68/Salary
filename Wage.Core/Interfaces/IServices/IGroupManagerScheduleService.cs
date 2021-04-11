using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IServices
{
    public interface IGroupManagerScheduleService
    {
        Task<GroupManagerSchedule> GetGroupManagerScheduleById(object id);
        Task<IEnumerable<GroupManagerSchedule>> GetAllGroupManagerSchedules();
        Task<IEnumerable<GroupManagerSchedule>> GetManyGroupManagerSchedules(Expression<Func<GroupManagerSchedule, bool>> whereClause);
        Task<bool> EditGroupManagerSchedule(GroupManagerSchedule item);
        Task<bool> AddGroupManagerSchedule(GroupManagerSchedule item);
        Task<bool> RemoveGroupManagerSchedule(object id);
    }
}
