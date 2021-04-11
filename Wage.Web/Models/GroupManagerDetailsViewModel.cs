using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.Models
{
    public class GroupManagerDetailsViewModel
    {        
        public string EntranceDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
        public bool IsOnline{ get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string MinTime { get; set; }
        public decimal GroupManagerId { get; set; }
    }
}
