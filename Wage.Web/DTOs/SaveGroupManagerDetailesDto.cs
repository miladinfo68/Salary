using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class SaveGroupManagerDetailesDto
    {
        //public decimal Id { get; set; }
        public string EntranceDate { get; set; }        
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public bool IsOnline { get; set; } = false;
        public decimal GroupManagerId { get; set; }
    }
}
