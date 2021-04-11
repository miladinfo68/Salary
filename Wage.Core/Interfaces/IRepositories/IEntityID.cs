using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Interfaces.IRepositories
{
    public interface IEntityID<TId> //where TId : class
    {
        TId Id { get; set; }
    }
}
