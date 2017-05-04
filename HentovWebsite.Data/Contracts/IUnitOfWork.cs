using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.Entity.Portfolio;
using HentovWebsite.Models.Entity.Tutorials;
using HentovWebsite.Models.Entity.Users;

namespace HentovWebsite.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<CommentEntityModel> Comments { get; }

        IRepository<PostEntityModel> Posts { get; }

        IRepository<TutorialEntityModel> Tutorials { get;  }

        IRepository<WebsiteUser> WebsiteUsers { get; }

        IRepository<TagEntityModel> Tags { get; }

        IRepository<ProjectEntityModel> Projects { get; }

        IRepository<ApplicationUser> Users { get; }
        int SaveChanges();
    }
}
