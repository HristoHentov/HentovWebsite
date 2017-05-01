using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public byte[] Thumbnail { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 4)]
        public string Title { get; set; }
        [StringLength(maximumLength: 3000, MinimumLength = 4)]
        public string Description { get; set; }

        public long Length { get; set; } //TODO: This can be a string or custom time format.
        [RegularExpression("(?:https?:\\/\\/)?(?:www\\.)?youtu\\.?be(?:\\.com)?\\/?.*(?:watch|embed)?(?:.*v=|v\\/|\\/)([\\w\\-_]+)\\&?")]
        public string VideoUrl { get; set; }

        public ICollection<CommentEntityModel> Comments { get; set; }
    }
}
