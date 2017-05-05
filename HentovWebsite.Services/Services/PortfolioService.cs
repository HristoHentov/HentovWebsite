using System;
using System.Collections.Generic;
using AutoMapper;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Binding.Portfolio;
using HentovWebsite.Models.Entity.Portfolio;
using HentovWebsite.Models.Enums;
using HentovWebsite.Models.View.Portfolio;
using HentovWebsite.Services.Services.Contracts;

namespace HentovWebsite.Services.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork context;

        public PortfolioService(IUnitOfWork context)
        {
            this.context = context;
        }
        public void AddProject(AddProjectBindingModel project)
        {
            var projectToAdd = Mapper.Map<AddProjectBindingModel, ProjectEntityModel>(project);
            projectToAdd.ProjectType = (ProjectTypes)Enum.Parse(typeof(ProjectTypes), project.Type);
            this.context.Projects.Add(projectToAdd);
            this.context.SaveChanges();
        }

        public IEnumerable<ProjectViewModel> GetProjects(ProjectTypes type)
        {
            var projects = Mapper
                .Map<IEnumerable<ProjectEntityModel>, IEnumerable<ProjectViewModel>>
                (this.context.Projects.Where(p => p.ProjectType == type));

            return projects;
        }

        public void EditProject(EditProjectBindingModel project)
        {
            var projectToEdit = this.context.Projects.Find(project.Id);
            projectToEdit.Name = project.Name;
            projectToEdit.Description = project.Description;
            projectToEdit.ProjectLink = project.ProjectLink;
            projectToEdit.Thumbnail= project.Thumbnail;
            this.context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            this.context.Projects.Remove(id);
            this.context.SaveChanges();
        }

        public ProjectViewModel GetProjectViewModel(EditProjectBindingModel project)
        {
            return Mapper.Map<EditProjectBindingModel, ProjectViewModel>(project);
        }
    }
}