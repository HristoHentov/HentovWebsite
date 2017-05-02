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
    }
}