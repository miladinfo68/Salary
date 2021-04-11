using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Entities
{
    public class Holiday: BaseModel
    {
        public string HolidayDate { get; set; }
        public string Note { get; set; }
    }
}
