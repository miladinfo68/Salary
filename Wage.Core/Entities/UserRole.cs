using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Entities
{
    public class UserRole:BaseModel
    {

        public decimal? UserId { get; set; }
        public User User { get; set; }

        public decimal? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
