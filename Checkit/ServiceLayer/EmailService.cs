using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using CheckIt.DataAccessLayer;

namespace CheckIt.ServiceLayer
{
    public class EmailService
    {
        public void SendMail(string recipient, string subject, string messageBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("CheckIt", "spyderzdevs@gmail.com"));
            message.To.Add(new MailboxAddress(recipient.Split('@')[0], recipient));
            message.Subject = subject;

            var builder = new BodyBuilder();

            builder.TextBody = messageBody;

            message.Body = builder.ToMessageBody();

            try
            {
                var client = new SmtpClient();

                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("spyderzdevs@gmail.com", "AlexIsAlwaysLate_69");
                client.Send(message);
                client.Disconnect(true);

                Console.WriteLine("Send Mail Success.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Send Mail Failed : " + e.Message);
            }

        }

        public void SendAlertMail(List<User> users, string subject, string messageBody)
        {
            try
            {
                //declare vars
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("CheckIt", "spyderzdevs@gmail.com"));
                message.Subject = subject;
                //add users to recipients
                foreach(User user in users)
                {
                    message.To.Add(new MailboxAddress(user.userEmail.Split('@')[0], user.userEmail));
                }

                var builder = new BodyBuilder();
                builder.TextBody = messageBody;
                message.Body = builder.ToMessageBody();

                var client = new SmtpClient();

                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("spyderzdevs@gmail.com", "AlexIsAlwaysLate_69");
                client.Send(message);
                client.Disconnect(true);

            }
            catch (Exception)
            {

            }
        }
    }
}
