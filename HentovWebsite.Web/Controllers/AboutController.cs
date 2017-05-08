using System.Net.Mail;
using System.Web.Mvc;
using HentovWebsite.Models.Binding.About;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;

namespace HentovWebsite.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService service;

        public AboutController(IAboutService service)
        {
            this.service = service;
        }
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult SendMail(SendMailBindingModel model)
        {
            var sendMailresult = this.service.SendMail(
                  model,
                  Consts.GmailSmtpHost,
                  Consts.GmailSmtpPort,
                  Consts.AdminMailCredential,
                  Consts.AdminPassowrdCredential,
                  Consts.AdminMailRecepient);

            if (sendMailresult)
                return RedirectToAction("Index", "Home"); //TODO: Redirect to actual message sent successfully page.

            return RedirectToAction("Index", "Home");
        }
    }
}