using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("MyEmail", "MyPassword");
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("MyEmail", "MyEmail Display");
                    mailMessage.To.Add(new MailAddress("Email"));
                    mailMessage.Subject = "Test Email from SMTP";
                    mailMessage.Body = "This is the text...";

                    client.Send(mailMessage);
                }
            }
        }
    }
}
