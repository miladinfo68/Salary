using Wage.Core.Interfaces.IRepositories;

namespace Wage.Core.Entities
{
    public abstract class BaseModel:IEntityID<decimal>
    {
        public decimal Id { get; set; }
        public bool Active { get; set; } = true;
       
    }
}
