using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace CheckIt.ServiceLayer
{
    public class EmailService
    {
        public static void SendMail(string recipient, string messageBody)
        {
            //Attempted implementation of smtp email send. Doesn't work for authentication reasons.... :(
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential("spyderzdevs@gmail.com", "AlexIsAlwaysLate_69");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("SpyderzDevs@gmail.com", "CheckIt");
            mail.To.Add(new MailAddress(recipient));
            mail.Subject = "Notification from CheckIt";
            mail.IsBodyHtml = true;
            mail.Body = messageBody;

            smtpClient.Send(mail);
        }
    }
}
