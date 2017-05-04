using System.Collections.Generic;
using HentovWebsite.Models.Entity.Blog;

namespace HentovWebsite.Models.Binding.Blog
{
    public class AddPostBindingModel
    {
        public AddPostBindingModel(ICollection<TagEntityModel> tags)
        {
            this.Tags = tags;
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }
        public ICollection<TagEntityModel> Tags { get; set; }
    }
}
