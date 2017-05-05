using System.ComponentModel.DataAnnotations;
using HentovWebsite.Models.Configuration;
using HentovWebsite.Models.Validation;

namespace HentovWebsite.Models.Binding.Portfolio
{
    public class AddProjectBindingModel
    {
        [Required]
        [StringLength(Constraints.TitleMinLen, MinimumLength = Constraints.TitleMinLen)]
        public string Name { get; set; }
        [Required]
        [StringLength(Constraints.DescriptMaxLen, MinimumLength = Constraints.DescriptMinLen)]
        public string Description { get; set; }
        [Required]
        [UrlLink]
        public string ProjectLink { get; set; }
        public string Type { get; set; }
        [Required]
        public string Thumbnail { get; set; }

    }
}
