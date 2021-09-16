using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

// https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-5.0&tabs=visual-studio
namespace NotDefterim.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string sender = "notdefterim@kod.fun";
            MailMessage mail = new MailMessage(sender, email, subject, htmlMessage);
            mail.IsBodyHtml = true;

            using (SmtpClient smtp = new SmtpClient("mail.kod.fun", 587))
            {
                smtp.Credentials = new NetworkCredential("notdefterim@kod.fun", "[Parola]");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
