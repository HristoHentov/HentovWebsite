using System;
using System.Collections.Generic;

namespace HentovWebsite.Models.View.Blog
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {
            this.Replies = new List<CommentViewModel>();
        }
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime TimeCreated { get; set; }

        public ICollection<CommentViewModel> Replies { get; set; }
    }
}
