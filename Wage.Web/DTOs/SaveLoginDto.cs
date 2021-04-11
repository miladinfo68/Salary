using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class SaveLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RemmemberMe { get; set; } = false;

    }
}
