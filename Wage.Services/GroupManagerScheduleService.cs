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
    public class GroupManagerScheduleService : IGroupManagerScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupManagerScheduleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public virtual async Task<GroupManagerSchedule> GetGroupManagerScheduleById(object id)
        {
            var item = await _unitOfWork.GroupManagerSchedules.GetByIdAsync(id);
            return item;
        }

        public virtual async Task<IEnumerable<GroupManagerSchedule>> GetAllGroupManagerSchedules()
        {
            var list = await _unitOfWork.GroupManagerSchedules.GetAllAsync();
            return list;
        }


        public virtual async Task<bool> EditGroupManagerSchedule(GroupManagerSchedule item)
        {
            await _unitOfWork.GroupManagerSchedules.EditAsync( item);
            int x = await _unitOfWork.CommitAsync();
            return x > 0 ? true : false;
        }

        public virtual async Task<bool> AddGroupManagerSchedule(GroupManagerSchedule item)
        {
            await _unitOfWork.GroupManagerSchedules.EditAsync(item);
            int x = await _unitOfWork.CommitAsync();
            return x > 0 ? true : false;
        }

        public virtual async Task<bool> RemoveGroupManagerSchedule(object id)
        {
            await _unitOfWork.GroupManagerSchedules.RemoveByIdAsync(id);
            int x = await _unitOfWork.CommitAsync();
            return x > 0 ? true : false;
        }

        public virtual async Task<IEnumerable<GroupManagerSchedule>> GetManyGroupManagerSchedules(Expression<Func<GroupManagerSchedule, bool>> whereClause)
        {
            var list = await _unitOfWork.GroupManagerSchedules.GetManyAsync(whereClause);
            return list;
        }

      
    }
}
