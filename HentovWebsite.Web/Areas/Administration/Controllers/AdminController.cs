using System.Web.Mvc;

namespace HentovWebsite.Web.Areas.Administration.Controllers
{
    public class AdminController : Controller
    {
        // GET: Administration/Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddTutorial()
        {
            return View();
        }
    }
}