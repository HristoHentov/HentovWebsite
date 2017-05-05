using System.Web.Mvc;

namespace HentovWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}