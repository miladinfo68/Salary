using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Entities
{
    public class AccessLink:BaseModel
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public List<RoleAccess> RoleAccesses { get; set; }

        
    }
}
