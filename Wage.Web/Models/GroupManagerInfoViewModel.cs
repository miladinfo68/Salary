using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.Models
{
    public class GroupManagerInfoViewModel
    {
        public decimal Id { get; set; }
        public string ProfCode { get; set; }
        public string ProfName { get; set; }
        public string EntranceDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public bool IsOnline { get; set; } = false;
        public bool ResearchCouncil { get; set; } = false;
        public string MinTime { get; set; }
        public string BaseAmountInMonth { get; set; }
        //public decimal GroupManagerId { get; set; }
    }
}
