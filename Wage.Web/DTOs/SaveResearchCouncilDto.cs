using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class SaveResearchCouncilDto
    {
        public decimal Id { get; set; }             
        public bool ChkCouncil { get; set; } = false;       
        public string CouncilDate { get; set; }
    }
}
