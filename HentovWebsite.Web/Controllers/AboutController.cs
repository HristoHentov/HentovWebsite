using System.Web.Mvc;
using HentovWebsite.Models.Binding.About;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;

namespace HentovWebsite.Web.Controllers
{
    [RoutePrefix("About")]
    public class AboutController : Controller
    {
        private readonly IAboutService service;

        public AboutController(IAboutService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("SendMail")]
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
                return RedirectToAction("MessageSent", "About");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("MessageSent")]
        public ActionResult MessageSent()
        {
            return View();
        }
    }
}