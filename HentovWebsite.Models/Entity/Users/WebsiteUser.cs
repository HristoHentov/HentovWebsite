using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HentovWebsite.Models.Entity.Blog;

namespace HentovWebsite.Models.Entity.Users
{
    public class WebsiteUser
    {
        public WebsiteUser()
        {
            this.Comments = new List<CommentEntityModel>();
            this.LikedPosts = new List<PostEntityModel>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ApplicationUser IdentityUser { get; set; }
        public virtual ICollection<PostEntityModel> LikedPosts { get; set; }
        public virtual ICollection<CommentEntityModel> Comments { get; set; }
    }
}
