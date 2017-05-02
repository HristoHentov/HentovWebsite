using System.ComponentModel.DataAnnotations;

namespace HentovWebsite.Models.Binding.Tutorials
{
    public class AddTutorialBindingModel
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 4)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 3000, MinimumLength = 4)]
        public string Description { get; set; }
        public byte[] Thumbnail { get; set; }
        [RegularExpression("(?:https?:\\/\\/)?(?:www\\.)?youtu\\.?be(?:\\.com)?\\/?.*(?:watch|embed)?(?:.*v=|v\\/|\\/)([\\w\\-_]+)\\&?")]
        public string VideoUrl { get; set; }
    }
}
