using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Entities
{
    public class User:BaseModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpireTime { get; set; }
        public List<UserRole> UserRoles { get; set; }       
    }
}
