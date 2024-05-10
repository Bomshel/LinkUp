using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlogApp.Helpers
{
    /// <summary>
    /// Represents a service for sending emails.
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Sends an email asynchronously.
        /// </summary>
        /// <param name="mailRequest">The <see cref="MailMessage"/> object containing email details.</param>
        /// <param name="toEmail">The recipient's email address.</param>
        /// <param name="isBccRequired">Specifies whether blind carbon copy (Bcc) is required.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SendEmailAsync(MailMessage mailRequest, string toEmail = "", bool isBccRequired = false);

        /// <summary>
        /// Sends a notification email asynchronously.
        /// </summary>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="body">The body of the email.</param>
        /// <param name="toEmail">The recipient's email address.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SendNotification(string subject, string body, string toEmail);
    }

}
