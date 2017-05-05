using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HentovWebsite.Models.Configuration;
using HentovWebsite.Models.Entity.Blog;

namespace HentovWebsite.Models.Entity.Tutorials
{
    [Table("Tutorials")]
    public class TutorialEntityModel
    {
        public TutorialEntityModel()
        {
            this.Comments = new List<CommentEntityModel>();
        }
        public int Id { get; set; }

        public string Thumbnail { get; set; }

        [Required]
        [StringLength(maximumLength: Constraints.TitleMaxLen, MinimumLength = Constraints.TitleMinLen)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: Constraints.DescriptMaxLen, MinimumLength = Constraints.DescriptMinLen)]
        public string Description { get; set; }
        [RegularExpression(Constraints.YouTubeRegex)]
        public string VideoUrl { get; set; }
        public long Length { get; set; }
        public ICollection<CommentEntityModel> Comments { get; set; }
    }
}
