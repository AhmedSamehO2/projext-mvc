using meta.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace meta.BLL.Helper
{
    public static class MailSender
    {
        public static string SendMail(MailVM model)
        {
            try
            {

                using (var smtp = new SmtpClient("smtp.ethereal.email", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("iliana.fahey36@ethereal.email", "kUd6myMAFa4BVjHcKx");
                    smtp.Send("iliana.fahey36@ethereal.email", "ahmedsamehlotfi@gmail.com", model.Title, model.Message);
                }

                return "Done !  Mail Sent Successfully";

            }
            catch (Exception ex)
            {
                return "Faild To Send";
                
            }
        }
    }
}
