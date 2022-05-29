using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Mail
    {
      
        public static bool SendMail(Secretary secretary)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("metakteken@gmail.com");
                mail.To.Add(secretary.Email);
                mail.Body = "<h2>ך<h2>"+" <h3  >secretary.Password <h3>" ;
                mail.Subject = "סיסמתך למערכת מתקתקן";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
               SmtpServer.Credentials = new System.Net.NetworkCredential("metakteken@gmail.com", "0527618314");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
