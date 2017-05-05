using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HentovWebsite.Models.Configuration;
using HentovWebsite.Models.Enums;
using HentovWebsite.Models.Validation;

namespace HentovWebsite.Models.Entity.Portfolio
{
    [Table(name:"Projects")]
    public class ProjectEntityModel
    {
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
        public ProjectTypes ProjectType { get; set; }
    }
}
