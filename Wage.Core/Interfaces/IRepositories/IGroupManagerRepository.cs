﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wage.Core.Entities;

namespace Wage.Core.Interfaces.IRepositories
{
    public interface IGroupManagerRepository : IBaseRepository<GroupManager>
    {
        //Task<IEnumerable<GroupManager>> GetAllEntranceInfoAsync();
    }
}
