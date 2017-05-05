using System.ComponentModel.DataAnnotations;

namespace HentovWebsite.Models.Binding.Portfolio
{
    public class AddProjectBindingModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(1600, MinimumLength = 3)]
        public string Description { get; set; }
        public string ProjectLink { get; set; }
        public string Type { get; set; }
        public string Thumbnail { get; set; }

    }
}
