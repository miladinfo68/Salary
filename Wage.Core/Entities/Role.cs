using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Entities
{
    public class Role:BaseModel
    {
        public string RoleName { get; set; }
        public string DisplayName { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<RoleAccess> RoleAccesses { get; set; }
    }
}
