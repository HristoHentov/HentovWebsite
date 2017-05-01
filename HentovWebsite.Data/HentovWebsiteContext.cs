using System.Data.Entity;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.Entity.Tutorials;
using HentovWebsite.Models.Entity.Users;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HentovWebsite.Data
{
    public class HentovWebsiteContext : IdentityDbContext<ApplicationUser>
    {
        public HentovWebsiteContext()
            : base("HentovWebsiteConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<CommentEntityModel> Comments { get; set; }

        public DbSet<PostEntityModel> Posts { get; set; }

        public DbSet<TutorialEntityModel> Tutorials { get; set; }

        public DbSet<WebsiteUser> WebsiteUsers { get; set; }

        public DbSet<TagEntityModel> Tags { get; set; }

        public static HentovWebsiteContext Create()
        {
            return new HentovWebsiteContext();
        }
    }
}