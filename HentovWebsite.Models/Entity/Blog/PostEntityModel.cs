using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HentovWebsite.Models.Entity.Blog
{
    [Table("Posts")]
    public class PostEntityModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 4)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 12000, MinimumLength = 4)]
        public string Content { get; set; }
        [Required]
        public string AuthorName { get; set; }

        public DateTime? DatePosted { get; set; }

        public DateTime? DateEdited { get; set; }

        public virtual List<CommentEntityModel> Comments { get; set; }
    }
}
