using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using HentovWebsite.Models.Binding.Tutorials;
using HentovWebsite.Models.View.Tutorials;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;

namespace HentovWebsite.Web.Controllers
{
    [RoutePrefix("Tutorials")]
    public class TutorialsController : Controller
    {
        private readonly ITutorialsService service;

        public TutorialsController(ITutorialsService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("Index")]
        [OutputCache(Duration = 30, Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var tutorials = this.service.GetAllTutorials().ToList();
            return View(tutorials);
        }

        [HttpPost]
        [Route("AddTutorial")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddTutorial(AddTutorialBindingModel tutorial)
        {
            if (ModelState.IsValid)
            {
                this.service.AddTutorial(tutorial);
                return RedirectToAction("Index");
            }

            return RedirectToAction("AddTutorial", "Admin", new {area = "Administration"});
        }

        [HttpGet]
        [Route("Tutorial/{id}")]
        [OutputCache(Duration = 30, Location = OutputCacheLocation.Client)]
        public ActionResult Tutorial(int id)
        {
            var tutorialInfo = this.service.GetTutorialById(id);
            return View(tutorialInfo);
        }

        [HttpGet]
        [Route("Edit")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(TutorialViewModel tutorial)
        {
            return View(tutorial);
        }

        [HttpPost]
        [Route("Edit")]
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
        [Route("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(TutorialViewModel tutorial)
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
                this.service.DeleteTutorial(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw new InvalidOperationException(Consts.DeleteTutorialError);
            }
        }
    }
}