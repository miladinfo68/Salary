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
    public class HolidayService : IHolidayService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HolidayService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public virtual async Task<Holiday> GetHolidayById(object id)
        {
            var item = await _unitOfWork.Holidays.GetByIdAsync(id);
            return item;
        }

        public virtual async Task<IEnumerable<Holiday>> GetAllHolidays()
        {
            var list = await _unitOfWork.Holidays.GetAllAsync();
            return list;
        }

        public virtual async Task<bool> EditHoliday(Holiday item)
        {
            await _unitOfWork.Holidays.EditAsync(item);
            int x = await _unitOfWork.CommitAsync();
            return x > 0 ? true : false;
        }

        public virtual async Task<bool> AddHoliday(Holiday item)
        {
            var itemres=await _unitOfWork.Holidays.AddAsync(item);
            int x = await _unitOfWork.CommitAsync();
            return x > 0 ? true : false;
        }

        public virtual async Task<IEnumerable<Holiday>> GetManyHolidays(Expression<Func<Holiday, bool>> whereClause)
        {
            var list = await _unitOfWork.Holidays.GetManyAsync(whereClause);
            return list;
        }

        public virtual async Task<bool> IsExists(object id)
        {
            var res = await _unitOfWork.Holidays.IsExists(id);
            return res;
        }

        public virtual async Task<bool> IsExists(Expression<Func<Holiday, bool>> whereClause)
        {
            var res = await _unitOfWork.Holidays.IsExists(whereClause);
            return res;
        }

        public virtual async Task<bool> RemoveHoliday(Holiday date)
        {
            var res = await _unitOfWork.Holidays.RemoveAsync(date);
            int x = await _unitOfWork.CommitAsync();
            return x > 0 ? true : false;
        }
    }
}
