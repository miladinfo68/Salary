using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class SaveGroupManagerScheduleDto
    {
        public string EntranceDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public string MinTime { get; set; }
        public decimal GroupManagerId { get; set; }        
        public bool Active { get; set; } = true;
    }
}
