using System.ComponentModel.DataAnnotations;
using HentovWebsite.Models.Configuration;

namespace HentovWebsite.Models.Binding.Blog
{
    public class EditPostBindingModel
    {   [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: Constraints.TitleMaxLen, MinimumLength = Constraints.TitleMinLen)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: Constraints.PostContentMaxLen, MinimumLength = Constraints.PostContentMinLen)]
        public string Content { get; set; }
    }
}
