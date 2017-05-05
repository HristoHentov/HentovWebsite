using System.Collections.Generic;
using HentovWebsite.Models.Binding.Tutorials;
using HentovWebsite.Models.View.Tutorials;

namespace HentovWebsite.Services.Services.Contracts
{
    public interface ITutorialsService : IService
    {
        void AddTutorial(AddTutorialBindingModel tutorial);
        IEnumerable<TutorialViewModel> GetAllTutorials();
        TutorialViewModel GetTutorialById(int id);
        void EditTutorial(EditTutorialBindingModel tutorial);
        void DeleteTutorial(int id);
        TutorialViewModel GetTutorialViewModel(EditTutorialBindingModel tutorial);
    }
}
