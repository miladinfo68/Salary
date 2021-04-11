using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class RoleDto
    {
        public decimal Id { get; set; }
        public string RoleName { get; set; }
        public string DisplayName { get; set; }
        public bool Checked { get; set; } = false;
        //public bool Disabled { get; set; } = false;
        //public decimal UserId { get; set; }
    }
}
