using System.ComponentModel.DataAnnotations;

namespace HentovWebsite.Models.Entity.Blog
{
    public class TagEntityModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
