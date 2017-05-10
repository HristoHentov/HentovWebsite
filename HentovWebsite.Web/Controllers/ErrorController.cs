using System.Web.Mvc;

namespace HentovWebsite.Web.Controllers
{
    [RoutePrefix("Error")]
    public class ErrorController : Controller
    {
        [Route("NotFound")]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}