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
    public class GroupManagerDetailesService : IGroupManagerDetailesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupManagerDetailesService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual async Task<bool> AddNewGroupManagerDetails(GroupManagerDetails item)
        {
            int x = 0;
            var fetched = await _unitOfWork.GroupManagerDetailes.FindOneAsync(w => w.GroupManagerId == item.GroupManagerId
                       && w.EntranceDate == item.EntranceDate
                       && w.IsOnline == item.IsOnline
           );

            if (fetched == null)
            {
                await _unitOfWork.GroupManagerDetailes.AddAsync(item);
                x = await _unitOfWork.CommitAsync();
            }
            else
            {
                TimeSpan newEntranceTime = TimeSpan.Parse(item.EntranceTime);
                TimeSpan oldExitTime = TimeSpan.Parse(fetched.ExitTime);
                var isGreaterThan = newEntranceTime.CompareTo(oldExitTime);
                if (isGreaterThan > 0)
                {
                    await _unitOfWork.GroupManagerDetailes.AddAsync(item);
                    x = await _unitOfWork.CommitAsync();
                }
            }
            return x > 0 ? true : false;
        }

        public virtual async Task<bool> RemoveGroupManagerDetails(object id)
        {
            await _unitOfWork.GroupManagerDetailes.RemoveByIdAsync(id);
            int x = await _unitOfWork.CommitAsync();
            return x > 0 ? true : false;
        }

        public virtual async Task<IEnumerable<GroupManagerDetails>> GetAllGroupManagerDetails()
        {
            var list = await _unitOfWork.GroupManagerDetailes.GetAllAsync();
            return list;
        }

        public virtual async Task<IEnumerable<GroupManagerDetails>> GetManyGroupManagerDetails(Expression<Func<GroupManagerDetails, bool>> whereClause)
        {
            var list = await _unitOfWork.GroupManagerDetailes.GetManyAsync(whereClause);
            return list;
        }

        
    }
}
