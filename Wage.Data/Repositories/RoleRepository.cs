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
    public class RoleRepository : BaseRepository<Role> , IRoleRepository
    {
        public RoleRepository(WageDbContext context) : base(context) { }
        //other implements

               
        private WageDbContext WageDbContext
        {
            get { return Context as WageDbContext; }
        }
    }
}
