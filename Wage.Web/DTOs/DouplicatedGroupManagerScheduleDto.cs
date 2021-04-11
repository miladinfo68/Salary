using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class DouplicatedGroupManagerScheduleDto
    {
        public string EntranceDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public string MinTime { get; set; }
        public string GroupManagerId { get; set; }        
        public string Active { get; set; }
        public string IsOnline { get; set; } = "0";
        public string PresenceType { get; set; } = "فیزیکی";
    }

    public class TVP
    {
        public string EntranceDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public string MinTime { get; set; }
        public string GroupManagerId { get; set; }
        public bool Active { get; set; }
        public bool IsOnline { get; set; } = false;
    }
}
