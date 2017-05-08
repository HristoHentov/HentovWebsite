using HentovWebsite.Data;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.Entity.Portfolio;
using HentovWebsite.Models.Entity.Tutorials;
using HentovWebsite.Models.Entity.Users;

namespace HentovWebsite.Web.Tests.Mocks
{
    public class FakeWebsiteContext
    {
        public FakeWebsiteContext()
        {
            this.Comments = new FakeDbSet<CommentEntityModel>();
            this.Posts = new FakeDbSet<PostEntityModel>();
            this.Tutorials = new FakeDbSet<TutorialEntityModel>();
            this.WebsiteUsers = new FakeDbSet<WebsiteUser>();
            this.Tags = new FakeDbSet<TagEntityModel>();
            this.Projects = new FakeDbSet<ProjectEntityModel>();
            this.Users = new FakeDbSet<ApplicationUser>();
        }
        public FakeDbSet<CommentEntityModel> Comments { get; set; }

        public FakeDbSet<PostEntityModel> Posts { get; set; }

        public FakeDbSet<TutorialEntityModel> Tutorials { get; set; }

        public FakeDbSet<WebsiteUser> WebsiteUsers { get; set; }

        public FakeDbSet<TagEntityModel> Tags { get; set; }

        public FakeDbSet<ProjectEntityModel> Projects { get; set; }
        public FakeDbSet<ApplicationUser> Users { get; set; }

        public static FakeWebsiteContext Create()
        {
            return new FakeWebsiteContext();
        }
    }
}
