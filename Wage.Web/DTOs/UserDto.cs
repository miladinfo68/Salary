using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.DTOs
{
    public class UserDto
    {
        public decimal Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpireTime { get; set; }
        public bool Active { get; set; }
    }
}
