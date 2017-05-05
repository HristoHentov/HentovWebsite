using System.ComponentModel.DataAnnotations;
using HentovWebsite.Models.Configuration;
using HentovWebsite.Models.Validation;

namespace HentovWebsite.Models.Binding.Portfolio
{
    public class EditProjectBindingModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(Constraints.TitleMaxLen, MinimumLength = Constraints.TitleMinLen)]
        public string Name { get; set; }
        [Required]
        [StringLength(Constraints.DescriptMaxLen, MinimumLength = Constraints.DescriptMinLen)]
        public string Description { get; set; }
        [Required]
        [UrlLink]
        public string ProjectLink { get; set; }
        [Required]
        public string Thumbnail { get; set; }
    }
}
