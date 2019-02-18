using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogg.Models
{
    public partial class BlogPosts
    {

        public int PostId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must contain between 2 and 100 characters")]
        public string PostHeader { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Context is required")]
        [StringLength(2000, MinimumLength = 2, ErrorMessage = "Title must contain between 2 and 100 characters")]
        public string PostBreadText { get; set; }
        public DateTime DatePosted { get; set; }
        public int? CategoryId { get; set; }

        public virtual Categories Category { get; set; }
    }
}
