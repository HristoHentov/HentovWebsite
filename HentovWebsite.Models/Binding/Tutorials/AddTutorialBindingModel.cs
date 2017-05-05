using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using HentovWebsite.Models.Configuration;

namespace HentovWebsite.Models.Binding.Tutorials
{
    public class AddTutorialBindingModel
    {
        [Required]
        [StringLength(maximumLength: Constraints.TitleMaxLen, MinimumLength = Constraints.TitleMinLen)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: Constraints.DescriptMaxLen, MinimumLength = Constraints.DescriptMinLen)]
        public string Description { get; set; }
        [RegularExpression(Constraints.YouTubeRegex)]
        public string VideoUrl { get; set; }
        public string Length { get; set; }
        public string VideoId
        {
            get
            {
                var match = Regex.Match(this.VideoUrl,Constraints.YouTubeRegex);
                return match.Groups[1].ToString();
            }
        }
    }
}
