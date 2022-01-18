
using System;
using System.Net;
using System.Net.Mail;

namespace Utilities
{
    public static class SendEmail
    {
        public static void SendReservationEmail(this string email)
        {
            SmtpClient smtp = new SmtpClient("smtp.google.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(Credentials.Email, Credentials.Password)
            };

            MailMessage message = new MailMessage(Credentials.Email, email);
            message.Subject = "Thank you for your reservation";
            message.Body = "Hi.We just got your reservation. We are looking forward to see you in out hotel. " +
                 "If you have any requests or questions please contact us. " +
                "Please do not " + "answer this message.";
            smtp.Send(message);

        }

        public static void SendConfirmationEmail(this string email)
        {
            SmtpClient smtp = new SmtpClient("smtp.google.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(Credentials.Email, Credentials.Password)
            };

            MailMessage message = new MailMessage(Credentials.Email, email);
            message.Subject = "Thank you for your registration";
            message.Body = "Hope you enjoy it";
            smtp.Send(message);

        }
    }
}
