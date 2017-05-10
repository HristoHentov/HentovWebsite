using System.Web.Mvc;

namespace HentovWebsite.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
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