using System.Collections.Generic;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Data.Repositories;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.Entity.Portfolio;
using HentovWebsite.Models.Entity.Tutorials;
using HentovWebsite.Models.Entity.Users;
using HentovWebsite.Web.Tests.Mocks;

public class FakeUnitOfWork : IUnitOfWork
{
    private FakeWebsiteContext context;
    private IRepository<CommentEntityModel> comments;
    private IRepository<PostEntityModel> posts;
    private IRepository<TutorialEntityModel> tutorials;
    private IRepository<WebsiteUser> websiteUsers;
    private IRepository<TagEntityModel> tags;
    private IRepository<ProjectEntityModel> projects;
    private IRepository<ApplicationUser> users;

    public FakeUnitOfWork()
    {
        this.context = new FakeWebsiteContext();
        this.comments = new Repository<CommentEntityModel>(this.context.Comments);
        this.posts = new Repository<PostEntityModel>(this.context.Posts);
        this.tutorials = new Repository<TutorialEntityModel>(this.context.Tutorials);
        this.websiteUsers = new Repository<WebsiteUser>(this.context.WebsiteUsers);
        this.tags = new Repository<TagEntityModel>(this.context.Tags);
        this.projects = new Repository<ProjectEntityModel>(this.context.Projects);
        this.users = new Repository<ApplicationUser>(this.context.Users);
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
        return 1;
    }
}
