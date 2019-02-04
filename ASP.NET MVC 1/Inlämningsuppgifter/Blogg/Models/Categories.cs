using System;
using System.Collections.Generic;

namespace Blogg.Models
{
    public partial class Categories
    {
        public Categories()
        {
            BlogPosts = new HashSet<BlogPosts>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<BlogPosts> BlogPosts { get; set; }
    }
}
