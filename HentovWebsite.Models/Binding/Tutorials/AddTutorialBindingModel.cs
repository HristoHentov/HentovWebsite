using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
        [RegularExpression("(?:https?:\\/\\/)?(?:www\\.)?youtu\\.?be(?:\\.com)?\\/?.*(?:watch|embed)?(?:.*v=|v\\/|\\/)([\\w\\-_]+)\\&?")]
        public string VideoUrl { get; set; }
        public string Length { get; set; }
        public string VideoId
        {
            get
            {
                var match = Regex.Match(this.VideoUrl,
                    "(?:https?:\\/\\/)?(?:www\\.)?youtu\\.?be(?:\\.com)?\\/?.*(?:watch|embed)?(?:.*v=|v\\/|\\/)([\\w\\-_]+)\\&?");

                return match.Groups[1].ToString();
            }
        }
    }
}
