using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.Models
{
    public class PresenceInMonthViewModel
    {
        public decimal Id { get; set; }
        public string ProfCode { get; set; }
        public string ProfName{ get; set; }
        public string BaseAmountInMonth { get; set; }
        public bool ResearchCouncil { get; set; }
        public string Month { get; set; }  
        public string OnlineTimeInWeek1 { get; set; }
        public string OnlineTimeInWeek2 { get; set; }
        public string OnlineTimeInWeek3 { get; set; }
        public string OnlineTimeInWeek4 { get; set; }
        public string OnlineTimeInWeek5 { get; set; }
        public string OfflineTimeInWeek1 { get; set; }
        public string OfflineTimeInWeek2 { get; set; }
        public string OfflineTimeInWeek3 { get; set; }
        public string OfflineTimeInWeek4 { get; set; }
        public string OfflineTimeInWeek5 { get; set; }
        public string TotalTimeInWeek1 { get; set; }
        public string TotalTimeInWeek2 { get; set; }
        public string TotalTimeInWeek3 { get; set; }
        public string TotalTimeInWeek4 { get; set; }
        public string TotalTimeInWeek5 { get; set; }
        public string TotalTimeInMounth{ get; set; }
        public string FinalAmountInWeek1 { get; set; }
        public string FinalAmountInWeek2 { get; set; }
        public string FinalAmountInWeek3 { get; set; }
        public string FinalAmountInWeek4 { get; set; }
        public string FinalAmountInMonth { get; set; }



    }
}
