using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class ChangePasswordDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
