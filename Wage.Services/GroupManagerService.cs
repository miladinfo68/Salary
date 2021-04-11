using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;
using Wage.Core.Interfaces;
using Wage.Core.Interfaces.IServices;

namespace Wage.Services
{
    public class GroupManagerService : IGroupManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupManagerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public virtual async Task<GroupManager> GetGroupManagerById(object id)
        {
            var item = await _unitOfWork.GroupManagers.GetByIdAsync(id);
            return item;
        }


        public virtual async Task<GroupManager> FindOneAsync(Expression<Func<GroupManager, bool>> whereClause)
        {
            var item = await _unitOfWork.GroupManagers.FindOneAsync(whereClause);
            return item;
        }

        public virtual async Task<IEnumerable<GroupManager>> GetAllGroupManagers(string year = "0", string month = "0", string startAt = "0")
        {
            IEnumerable<GroupManager> grList, res;
            //var cc = await _unitOfWork.GroupManagers.GetAllAsync();

            grList = (from gr in await _unitOfWork.GroupManagers.GetAllAsync()
                      let dbM = int.Parse(gr.Month)
                      let inM = int.Parse(month)
                      where
                             ((year != "0" && gr.Year == year) || (year == "0"))
                          && ((month != "0" && dbM == inM) || (month == "0"))
                          && ((startAt != "0" && gr.StartAt == startAt) || (startAt == "0"))
                      select gr);//.ToList();

            var uniqueList = grList?.Select(s => new GroupManager { ProfCode = s.ProfCode, Year = s.Year, Month = s.Month }).Distinct();//.ToList();

            res = (from x in uniqueList
                   join y in grList on new { x.ProfCode, x.Year, x.Month } equals new { y.ProfCode, y.Year, y.Month }
                   select y).ToList();

            return res;
        }

        //public virtual async  Task<IEnumerable<GroupManager>> GetAllEntranceInfoAsync()
        //{
        //    var list = await _unitOfWork.GroupManagers.GetAllEntranceInfoAsync();
        //    return list;
        //}

        public virtual async Task<List<GroupManager>> GetByFilterAsync(params Expression<Func<GroupManager, bool>>[] filters)
        {
            var list = await _unitOfWork.GroupManagers.GetByFilterAsync(filters);
            return list;
        }

        public virtual async Task<bool> EditGroupManagerInfo(GroupManager item)
        {
            await _unitOfWork.GroupManagers.EditAsync(item);
            int x = await _unitOfWork.CommitAsync();
            return x > 0 ? true : false;
        }

        public virtual async Task<IEnumerable<GroupManager>> GetManyGroupManagers(Expression<Func<GroupManager, bool>> whereClause)
        {
            var list = await _unitOfWork.GroupManagers.GetManyAsync(whereClause);
            return list;
        }

    }
}
