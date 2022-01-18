
using System;
using System.Net;
using System.Net.Mail;

namespace Utilities
{
    public static class SendEmail
    {
        public static void EmailSender(this string email,string subject, string body)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(Credentials.Email, Credentials.Password)
            };

            MailMessage message = new MailMessage(Credentials.Email, email);
            message.Subject = subject;
            message.Body = body;
            smtp.Send(message);

        }
  

       
    }
}
