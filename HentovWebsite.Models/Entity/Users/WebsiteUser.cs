using System.Collections.Generic;
using HentovWebsite.Models.Entity.Blog;

namespace HentovWebsite.Models.Entity.Users
{
    public sealed class WebsiteUser
    {
        public WebsiteUser()
        {
            this.Comments = new List<CommentEntityModel>();
        }
        public int Id { get; set; }
        public ApplicationUser IdentityUser { get; set; }
        public ICollection<CommentEntityModel> Comments { get; set; }
    }
}
