using System;
using System.Linq;
using System.Web.Mvc;
using HentovWebsite.Models.Binding.Tutorials;
using HentovWebsite.Models.View.Tutorials;
using HentovWebsite.Services.Services.Contracts;

namespace HentovWebsite.Web.Controllers
{
    public class TutorialsController : Controller
    {
        private readonly ITutorialsService service;

        public TutorialsController(ITutorialsService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var tutorials = this.service.GetAllTutorials().ToList();
            return View(tutorials);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddTutorial(AddTutorialBindingModel tutorial)
        {
            if (ModelState.IsValid)
            {
                this.service.AddTutorial(tutorial);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Manage");
        }
        [HttpGet]
        public ActionResult Tutorial(int id)
        {
            var tutorialInfo = this.service.GetTutorialById(id);
            return View(tutorialInfo);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(TutorialViewModel tutorial)
        {
            return View(tutorial);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditTutorialBindingModel tutorial)
        {
            if (ModelState.IsValid)
            {
                this.service.EditTutorial(tutorial);
                return RedirectToAction("Index");
            }

            var vm = this.service.GetTutorialViewModel(tutorial);
            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(TutorialViewModel tutorial)
        {
            return View(tutorial);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.service.DeleteTutorial(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Failed to delete tutorial!");
            }
        }
    }
}