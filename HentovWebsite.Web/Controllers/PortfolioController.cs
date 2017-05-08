using System;
using System.Linq;
using System.Web.Mvc;
using HentovWebsite.Models.Binding.Portfolio;
using HentovWebsite.Models.Enums;
using HentovWebsite.Models.View.Portfolio;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;

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

        [HttpPost]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(ProjectViewModel project)
        {
            return View(project);
        }
        [HttpPost]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(ProjectViewModel tutorial)
        {
            return View(tutorial);
        }

        [HttpPost]
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