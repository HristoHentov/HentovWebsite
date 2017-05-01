using System.Collections.Generic;
using HentovWebsite.Models.Entity.Blog;

namespace HentovWebsite.Models.Binding.Blog
{
    public class AddPostBindingModel
    {
        public AddPostBindingModel()
        {
            this.Tags = new List<TagEntityModel>();
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<TagEntityModel> Tags { get; set; }
        public string AuthorName { get; set; }
    }
}
