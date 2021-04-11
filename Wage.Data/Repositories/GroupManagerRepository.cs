using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;
using Wage.Core.Interfaces.IRepositories;

namespace Wage.Data.Repositories
{
    public class GroupManagerRepository: BaseRepository<GroupManager> , IGroupManagerRepository
    {
        public GroupManagerRepository(WageDbContext context): base(context){ }
        //other implements

        //public virtual async Task<IEnumerable<GroupManager>> GetAllEntranceInfoAsync()
        //{
        //    var list = await Context.GroupManagers
        //        .Include(a => a.GroupManagerDetails)
        //        .ToListAsync();
                
        //    return list;
        //}

        
        private WageDbContext WageDbContext
        {
            get { return Context as WageDbContext; }
        }
    }
}
