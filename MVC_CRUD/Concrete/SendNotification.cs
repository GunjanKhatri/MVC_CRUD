using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using MVC_CRUD.Interface;

namespace MVC_CRUD.Concrete
{
    public class SendNotification : INotification
    {
        public async Task SendNotificationToEmployee()
        {
            await Task.Run(() =>
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("advani.gunjan@gmail.com");
                message.To.Add(new MailAddress("advani.gunjan@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "Sucessfully you have registred";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("advani.gunjan@gmail.com", "Powerpuff17$");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            });
        }
    }
}