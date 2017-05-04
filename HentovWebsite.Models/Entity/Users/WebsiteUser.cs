using System.Collections.Generic;
using HentovWebsite.Models.Entity.Blog;

namespace HentovWebsite.Models.Entity.Users
{
    public class WebsiteUser
    {
        public WebsiteUser()
        {
            this.Comments = new List<CommentEntityModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser IdentityUser { get; set; }
        public ICollection<CommentEntityModel> Comments { get; set; }
    }
}
