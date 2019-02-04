using System;
using System.Collections.Generic;

namespace Blogg.Models
{
    public partial class BlogPosts
    {
        public int PostId { get; set; }
        public string PostHeader { get; set; }
        public string PostContext { get; set; }
        public string PostBreadText { get; set; }
        public DateTime DatePosted { get; set; }
        public int? CategoryId { get; set; }

        public virtual Categories Category { get; set; }
    }
}
