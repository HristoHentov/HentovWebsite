using System.Collections.Generic;

namespace HentovWebsite.Models.View.Blog
{
    public class PostCollectionViewModel
    {
        public PostCollectionViewModel()
        {
            this.Posts = new List<PostViewModel>();
        }
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
