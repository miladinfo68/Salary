using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IServices
{
    public interface IHolidayService
    {
        Task<Holiday> GetHolidayById(object id);
        Task<IEnumerable<Holiday>> GetAllHolidays();
        Task<IEnumerable<Holiday>> GetManyHolidays(Expression<Func<Holiday, bool>> whereClause);
        Task<bool> EditHoliday(Holiday item);
        Task<bool> AddHoliday(Holiday item);
        Task<bool> RemoveHoliday(Holiday date);
        Task<bool> IsExists(object id);
        Task<bool> IsExists(Expression<Func<Holiday, bool>> whereClause);
    }
}
