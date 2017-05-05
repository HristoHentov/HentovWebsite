using System.ComponentModel.DataAnnotations;
using HentovWebsite.Models.Configuration;

namespace HentovWebsite.Models.Binding.Blog
{
    public class CommentBindingModel
    {
        [Required]
        public string User { get; set; }
        [Required]
        [StringLength(maximumLength: Constraints.CommentContentMaxLen, MinimumLength = Constraints.CommentContentMinLen)]
        public string Content { get; set; }
    }
}
