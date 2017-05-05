using System.ComponentModel.DataAnnotations;
using HentovWebsite.Models.Configuration;

namespace HentovWebsite.Models.Binding.Tutorials
{
    public class EditTutorialBindingModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: Constraints.DescriptMaxLen, MinimumLength = Constraints.DescriptMinLen)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: Constraints.DescriptMaxLen, MinimumLength = Constraints.DescriptMinLen)]
        public string Description { get; set; }
        [RegularExpression(Constraints.YouTubeRegex)]
        public string VideoUrl { get; set; }
    }
}
