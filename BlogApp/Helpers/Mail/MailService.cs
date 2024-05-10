using BlogApp.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Authentication;
using System.Threading.Tasks; 

namespace BlogApp.Helpers
{
    public class MailService : IMailService
    {
        private readonly EmailSettings _mailSettings;
        /// <summary>
        /// Initializes a new instance of the <see cref="MailService"/> class.
        /// </summary>
        /// <param name="emailSettings">Email settings injected via dependency injection.</param>
        public MailService(IOptions<EmailSettings> emailSettings)
        {
            _mailSettings = emailSettings.Value;
        }
        public Task SendEmailAsync(MailMessage mail,string toEmail="", bool isBccRequired = false)
        {
            mail.From = new MailAddress(_mailSettings.From, "Blog App");
            mail.IsBodyHtml = true;
                try
                {
                // Ignore certificate validation errors
                ServicePointManager.ServerCertificateValidationCallback =
                              (sender, certificate, chain, sslPolicyErrors) => true;
                // Disable 'Expect: 100-continue' behavior
                System.Net.ServicePointManager.Expect100Continue = false;
                // Set credentials if authentication is required
                var credentials = _mailSettings.AuthRequired ? new NetworkCredential(_mailSettings.From, _mailSettings.Password) : null;
                    using (SmtpClient client = new SmtpClient()
                    {
                        Host = _mailSettings.Host,
                        Port = _mailSettings.Port,
                        EnableSsl = _mailSettings.UseSsl,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = credentials,

                    })
                    // If toEmail is specified, send email to that address
                    if (toEmail != "")
                    {
                            var mailAddress = toEmail;
                            var to = new MailAddress(mailAddress);
                            using (MailMessage mail1 = new MailMessage(mail.From, to))
                            {
                                mail1.Body = mail.Body;
                                mail1.Subject = mail.Subject;
                                mail1.IsBodyHtml = true;
                                client.Send(mail1);
                            }
    
                    }
                    else
                    {
                        // Otherwise, send email normally
                        client.Send(mail);
                    }
                    
                }

                catch (Exception ex)
                {
                // Handle exception
                }

            return Task.CompletedTask;
        }
  
        public Task SendNotification(string subject, string body, string toEmail)
        {
            var mail = new MailMessage();
            mail.Subject = subject;
            mail.Body = body;
            return SendEmailAsync(mail, toEmail);
        }
    }
}
