

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wage.Core.Entities
{
    public class GroupManagerDetails :BaseModel
    {        
        public string EntranceDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public bool IsOnline { get; set; } = false;
        public decimal GroupManagerId { get; set; }
        public GroupManager GroupManager { get; set; }
    }
}
