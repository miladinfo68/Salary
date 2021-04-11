using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Entities
{
    public class RoleAccess:BaseModel
    {
        public decimal? RoleId { get; set; }
        public Role Role { get; set; }

        public decimal? AccessLinkId { get; set; }
        public AccessLink AccessLink { get; set; }        
    }
}
