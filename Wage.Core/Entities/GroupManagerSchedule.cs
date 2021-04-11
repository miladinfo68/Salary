using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Entities
{
    public class GroupManagerSchedule: BaseModel
    {
        public string EntranceDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public string MinTime { get; set; }
        public bool IsOnline { get; set; } = false;
        public decimal GroupManagerId { get; set; }
    }
}
