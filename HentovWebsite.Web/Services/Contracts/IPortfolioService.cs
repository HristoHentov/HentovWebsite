using System.Collections.Generic;
using HentovWebsite.Models.Binding.Portfolio;
using HentovWebsite.Models.Enums;
using HentovWebsite.Models.View.Portfolio;

namespace HentovWebsite.Web.Services.Contracts
{
    public interface IPortfolioService : IService
    {
        void AddProject(AddProjectBindingModel project);
        IEnumerable<ProjectViewModel> GetProjects(ProjectTypes type);
        void EditProject(EditProjectBindingModel project);
        void DeleteProject(int id);
    }
}