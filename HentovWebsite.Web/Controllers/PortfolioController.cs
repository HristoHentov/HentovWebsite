using System;
using System.Linq;
using System.Web.Mvc;
using HentovWebsite.Models.Binding.Portfolio;
using HentovWebsite.Models.Enums;
using HentovWebsite.Models.View.Portfolio;
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

        [HttpGet]
        public ActionResult Edit(ProjectViewModel project)
        {
            return View(project);
        }
        [HttpPost]
        public ActionResult Edit(EditProjectBindingModel project)
        {
            try
            {
                this.service.EditProject(project);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Failed to edit project");
            }
        }

        [HttpGet]
        public ActionResult Delete(ProjectViewModel tutorial)
        {
            return View(tutorial);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                this.service.DeleteProject(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Failed to delete project!");
            }
        }

    }
}