using HentovWebsite.Data.Contracts;
using HentovWebsite.Data.Repositories;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.Entity.Portfolio;
using HentovWebsite.Models.Entity.Tutorials;
using HentovWebsite.Models.Entity.Users;

namespace HentovWebsite.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HentovWebsiteContext context;
        private IRepository<CommentEntityModel> comments;
        private IRepository<PostEntityModel> posts;
        private IRepository<TutorialEntityModel> tutorials;
        private IRepository<WebsiteUser> websiteUsers;
        private IRepository<TagEntityModel> tags;
        private IRepository<ProjectEntityModel> projects;
        private IRepository<ApplicationUser> users;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public IRepository<CommentEntityModel> Comments =>
            this.comments ?? (this.comments = new Repository<CommentEntityModel>(this.context.Comments));
        public IRepository<PostEntityModel> Posts =>
            this.posts ?? (this.posts = new Repository<PostEntityModel>(this.context.Posts));
        public IRepository<TutorialEntityModel> Tutorials =>
             this.tutorials ?? (this.tutorials = new Repository<TutorialEntityModel>(this.context.Tutorials));
        public IRepository<WebsiteUser> WebsiteUsers =>
             this.websiteUsers ?? (this.websiteUsers = new Repository<WebsiteUser>(this.context.WebsiteUsers));
        public IRepository<TagEntityModel> Tags =>
            this.tags ?? (this.tags = new Repository<TagEntityModel>(this.context.Tags));
        public IRepository<ProjectEntityModel> Projects =>
            this.projects ?? (this.projects = new Repository<ProjectEntityModel>(this.context.Projects));
        public IRepository<ApplicationUser> Users =>
            this.users ?? (this.users = new Repository<ApplicationUser>(this.context.Users));

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

    }
}