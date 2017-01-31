using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using Microsoft.AspNet.Identity;

namespace SimpleChatSite
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            string config = ConfigurationManager.AppSettings["EmailServiceConfiguration"];
            var parts = config.Split(';');
            string host = parts.First(part => part.StartsWith("Host", StringComparison.OrdinalIgnoreCase)).Substring(5);
            int port =
                int.Parse(parts.First(part => part.StartsWith("Port", StringComparison.OrdinalIgnoreCase)).Substring(5));

            string login = parts.First(part => part.StartsWith("Login", StringComparison.OrdinalIgnoreCase)).Substring(6);
            string password = parts.First(part => part.StartsWith("Password", StringComparison.OrdinalIgnoreCase)).Substring(9);
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = host;
                smtp.Port = port;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(login, password);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(login);
                    mailMessage.To.Add(message.Destination);
                    mailMessage.Subject = message.Subject;
                    mailMessage.Body = message.Body;
                    mailMessage.IsBodyHtml = false;
                    await smtp.SendMailAsync(mailMessage);
                }
            }
        }
    }
}