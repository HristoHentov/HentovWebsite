using System;
using System.Collections.Generic;

namespace HentovWebsite.Models.View.Blog
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string AuthorName { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime? DateEdited { get; set; }

        public int CommentsCount { get; set; }
    }
}
