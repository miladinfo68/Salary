using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.Models
{
    public class PresenceInWeekViewModel
    {
        public decimal GroupManagerId { get; set; }
        public string ProfCode { get; set; }
        public string ProfName { get; set; }
        public bool ResearchCouncil { get; set; } 
        public string Month { get; set; }
        public string Week { get; set; }
        public string OnlineTotalTime { get; set; }
        public string PhysicalTotalTime { get; set; }
        public string TotalTime { get; set; }
        public string BaseAmountInWeek { get; set; }

    }
}
