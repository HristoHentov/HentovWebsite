using System.Linq;
using System.Web.Mvc;
using HentovWebsite.Models.Binding.Portfolio;
using HentovWebsite.Models.Enums;
using HentovWebsite.Web.Services.Contracts;

namespace HentovWebsite.Web.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService service;

        public PortfolioController(IPortfolioService portService)
        {
            this.service = portService;
        }
        // GET: Portfolio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Development()
        {
            var projects = this.service.GetProjects(ProjectTypes.Development).ToList();
            return View(projects);
        }

        public ActionResult Design()
        {
            var projects = this.service.GetProjects(ProjectTypes.Design).ToList();
            return View(projects);
        }

        public ActionResult AddProject(AddProjectBindingModel project)
        {
            this.service.AddProject(project);
            return RedirectToAction("Index");
        }
    }
}