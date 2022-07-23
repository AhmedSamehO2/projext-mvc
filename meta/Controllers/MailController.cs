using meta.BLL.Helper;
using meta.BLL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
namespace meta.Controllers
{
    public class MailController : Controller
    {
        public IActionResult CreateMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMail(MailVM model)
        {
            var result = MailSender.SendMail(model);

            TempData["Msg"]=result;
            return View();
        }
    }
}
