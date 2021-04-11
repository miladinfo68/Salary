using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Wage.Core.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task SendEmailAsync(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(message?.From ?? _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, false);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(emailMessage);
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception or both.
                    //throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        //private MimeMessage CreateEmailMessage(Message message)
        //{
        //    var emailMessage = new MimeMessage();
        //    emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
        //    emailMessage.To.AddRange(message.To);
        //    emailMessage.Subject = message.Subject;
        //    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

        //    return emailMessage;
        //}

        //private async Task SendAsync(MimeMessage mailMessage)
        //{
        //    using (var client = new SmtpClient())
        //    {
        //        try
        //        {
        //            client.Connect(_emailConfig.SmtpServer, _emailConfig.Port ,false);
        //            //client.AuthenticationMechanisms.Remove("XOAUTH2");
        //            client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
        //            await client.SendAsync(mailMessage);                    
        //        }
        //        catch(Exception ex)
        //        {
        //            //log an error message or throw an exception or both.
        //            throw;
        //        }
        //        finally
        //        {
        //            client.Disconnect(true);
        //            client.Dispose();
        //        }
        //    }
        //}
    }
}
