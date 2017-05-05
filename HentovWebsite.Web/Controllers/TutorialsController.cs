using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HentovWebsite.Models.Binding.Tutorials;
using HentovWebsite.Models.View.Tutorials;
using HentovWebsite.Web.Services.Contracts;

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
        public ActionResult Edit(TutorialViewModel tutorial)
        {
            return View(tutorial);
        }

        [HttpPost]
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
        public ActionResult Delete(TutorialViewModel tutorial)
        {
            return View(tutorial);
        }

        [HttpPost]
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