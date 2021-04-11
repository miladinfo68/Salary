using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace Wage.Core.EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }       
        public string From { get; set; } = null;
      
        public Message( IEnumerable<string> to, string subject, string content ,string from=null)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;
            From = from != null ? from : null;
        }
    }
}
