using System.Collections.Generic;
using HentovWebsite.Models.Binding.Tutorials;
using HentovWebsite.Models.View.Tutorials;

namespace HentovWebsite.Web.Services.Contracts
{
    public interface ITutorialsService : IService
    {
        void AddTutorial(AddTutorialBindingModel tutorial);
        IEnumerable<TutorialViewModel> GetAllTutorials();
        TutorialViewModel GetTutorialById(int id);
    }
}
