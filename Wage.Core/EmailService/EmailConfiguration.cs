using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.EmailService
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string From { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
