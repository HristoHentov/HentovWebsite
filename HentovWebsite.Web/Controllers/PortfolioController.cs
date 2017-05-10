using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using HentovWebsite.Models.Binding.Portfolio;
using HentovWebsite.Models.Enums;
using HentovWebsite.Models.View.Portfolio;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;

namespace HentovWebsite.Web.Controllers
{
    [RoutePrefix("Portfolio")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService service;

        public PortfolioController(IPortfolioService portService)
        {
            this.service = portService;
        }
        // GET: Portfolio
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Development")]
        [OutputCache(Duration = 30, Location = OutputCacheLocation.Client)]
        public ActionResult Development()
        {
            var projects = this.service.GetProjects(ProjectTypes.Development).ToList();
            return View(projects);
        }

        [HttpGet]
        [Route("Design")]
        [OutputCache(Duration = 30, Location = OutputCacheLocation.Client)]
        public ActionResult Design()
        {
            var projects = this.service.GetProjects(ProjectTypes.Design).ToList();
            return View(projects);
        }

        [HttpPost]
        [Route("AddProject")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProject(AddProjectBindingModel project)
        {
            if (ModelState.IsValid)
            {
                this.service.AddProject(project);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Manage");
        }

        [HttpGet]
        [Route("Edit")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(ProjectViewModel project)
        {
            return View(project);
        }

        [HttpPost]
        [Route("Edit")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditProjectBindingModel project)
        {
            if (ModelState.IsValid)
            {
                this.service.EditProject(project);
                return RedirectToAction("Index"); 
            }
            var vm = this.service.GetProjectViewModel(project);
            return View(vm);
        }

        [HttpGet]
        [Route("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(ProjectViewModel tutorial)
        {
            return View(tutorial);
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.service.DeleteProject(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw new InvalidOperationException(Consts.DeleteProjectError);
            }
        }

    }
}