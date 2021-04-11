using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class GroupManagerDto
    {
        public decimal Id { get; set; }
        public string ProfCode { get; set; }
        public string ProfName { get; set; }
        public string BaseAmount { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string StartAt { get; set; }
        public bool ChkCouncil { get; set; } = false;
        public string CouncilDate { get; set; }
    }
}
