using System.Web.Mvc;

namespace HentovWebsite.Web.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("~/")]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}