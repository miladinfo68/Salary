using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class DouplicatedGroupManagerDetailsDto
    {
        public string EntranceDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public string GroupManagerId { get; set; }
        public string IsOnline { get; set; }
        public string PresenceType { get; set; } = "فیزیکی";

    }

    public class TVPGroupManagerDetails
    {
        public Decimal GroupManagerId { get; set; }
        public string EntranceDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public Boolean Active { get; set; }
        public Boolean IsOnline { get; set; } = false;
    }
}
