using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.Entity.Tutorials;
using HentovWebsite.Models.Entity.Users;

namespace HentovWebsite.Data.Contracts
{
    public interface IUnitOfWork
    {
        ///TODO: Add all the IRepositroy<EntityDataModel> EntityDataModels {get; } here
        IRepository<CommentEntityModel> Comments { get; }

        IRepository<PostEntityModel> Posts { get; }

        IRepository<TutorialEntityModel> Tutorials { get;  }

        IRepository<WebsiteUser> WebsiteUsers { get; }

        IRepository<TagEntityModel> Tags { get; }
        int SaveChanges();
    }
}
