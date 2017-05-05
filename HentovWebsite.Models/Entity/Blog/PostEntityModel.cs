using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HentovWebsite.Models.Configuration;

namespace HentovWebsite.Models.Entity.Blog
{
    [Table("Posts")]
    public class PostEntityModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(Constraints.TitleMaxLen, MinimumLength = Constraints.TitleMinLen)]
        public string Title { get; set; }
        [Required]
        [StringLength(Constraints.PostContentMaxLen, MinimumLength = Constraints.CommentContentMinLen)]
        public string Content { get; set; }
        [Required]
        public string AuthorName { get; set; }

        public DateTime? DatePosted { get; set; }

        public DateTime? DateEdited { get; set; }

        public virtual List<CommentEntityModel> Comments { get; set; }
    }
}
