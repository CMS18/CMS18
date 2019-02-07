using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogg.Models
{
    public partial class BlogPosts
    {
        public int PostId { get; set; }
        public string PostHeader { get; set; }
        public string PostContext { get; set; }

        [DataType(DataType.MultilineText)]
        public string PostBreadText { get; set; }
        public DateTime DatePosted { get; set; }
        public int? CategoryId { get; set; }

        public virtual Categories Category { get; set; }
    }
}
