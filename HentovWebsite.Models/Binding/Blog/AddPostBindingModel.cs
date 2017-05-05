using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HentovWebsite.Models.Configuration;
using HentovWebsite.Models.Entity.Blog;

namespace HentovWebsite.Models.Binding.Blog
{
    public class AddPostBindingModel
    {
        public AddPostBindingModel()
        {
            this.Tags = new List<TagEntityModel>();
        }
        [Required]
        [StringLength(maximumLength: Constraints.TitleMaxLen, MinimumLength = Constraints.TitleMinLen)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: Constraints.PostContentMaxLen, MinimumLength = Constraints.PostContentMinLen)]
        public string Content { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public ICollection<TagEntityModel> Tags { get; set; }
    }
}
