using System.Collections.Generic;
using AutoMapper;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Binding.Tutorials;
using HentovWebsite.Models.Entity.Tutorials;
using HentovWebsite.Models.View.Tutorials;
using HentovWebsite.Web.Services.Contracts;

namespace HentovWebsite.Web.Services
{
    public class TutorialService : ITutorialsService
    {
        private readonly IUnitOfWork context;

        public TutorialService(IUnitOfWork uow)
        {
            this.context = uow;
        }
        public void AddTutorial(AddTutorialBindingModel tutorial)
        {
            var tutorialToAdd = Mapper.Map<AddTutorialBindingModel, TutorialEntityModel>(tutorial);
            this.context.Tutorials.Add(tutorialToAdd);
            this.context.SaveChanges();
        }

        public IEnumerable<TutorialViewModel> GetAllTutorials()
        {
            return Mapper.Map
                <IEnumerable<TutorialEntityModel>, IEnumerable<TutorialViewModel>>
                (this.context.Tutorials.Entities);
        }

        public TutorialViewModel GetTutorialById(int id)
        {
            return Mapper.Map
                <TutorialEntityModel, TutorialViewModel>
                (this.context.Tutorials.FirstOrDefault(t => t.Id == id));
        }

        public void EditTutorial(EditTutorialBindingModel tutorial)
        {
            var tutorialToEdit = this.context.Tutorials.Find(tutorial.Id);
            tutorialToEdit.Title = tutorial.Title;
            tutorialToEdit.Description = tutorial.Description;
            tutorialToEdit.VideoUrl = tutorial.VideoUrl;

            this.context.SaveChanges();
        }

        public void DeleteTutorial(int id)
        {
            this.context.Tutorials.Remove(id);
            this.context.SaveChanges();
        }
    }
}