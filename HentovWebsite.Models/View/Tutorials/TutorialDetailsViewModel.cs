using System.Collections.Generic;
using HentovWebsite.Models.Entity.Blog;
using HentovWebsite.Models.View.Blog;

namespace HentovWebsite.Models.View.Tutorials
{
    public class TutorialDetailsViewModel
    {
        public TutorialDetailsViewModel()
        {
            this.Comments = new List<CommentEntityModel>();
        }
        public string Name { get; set; }

        public string VideoUrl { get; set; }

        public string Description { get; set; }

        public ICollection<CommentEntityModel> Comments { get; set; }
    }
}
