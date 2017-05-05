using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HentovWebsite.Models.Entity.Blog
{
    [Table("Comments")]
    public class CommentEntityModel
    {
        public CommentEntityModel()
        {
            this.Replies = new List<CommentEntityModel>();
        }

        public int Id { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TimePosted { get; set; }

        public ICollection<CommentEntityModel> Replies { get; set; }
    }
}
