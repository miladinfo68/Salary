using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.Models
{
    public class GroupManagerViewModel
    {
        public decimal Id { get; set; }
        public string ProfCode { get; set; }
        public string ProfName{ get; set; }
        public bool ResearchCouncil { get; set; } = false;
        public string BaseAmountInMonth { get; set; }
    }
}
