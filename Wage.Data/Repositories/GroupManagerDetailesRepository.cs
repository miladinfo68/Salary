using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;
using Wage.Core.Interfaces.IRepositories;

namespace Wage.Data.Repositories
{
    public class GroupManagerDetailesRepository : BaseRepository<GroupManagerDetails> , IGroupManagerDetailesRepository
    {
        public GroupManagerDetailesRepository(WageDbContext context) : base(context){ }
        //other implements

        //public async Task<IEnumerable<GroupManager>> GetAllGroupManagerInfoAsync()
        //{
        //    return await Context.GroupManagers
        //        .Include(a => a.GroupManagerDetails)
        //        .ToListAsync();
        //}

        private WageDbContext WageDbContext
        {
            get { return Context as WageDbContext; }
        }
    }
}
