using System;
using System.Collections.Generic;

namespace Övningsuppgift3.Models
{
    public partial class Articles
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleText { get; set; }
        public string ArticleSummary { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? DatePosted { get; set; }

        public virtual Categories Category { get; set; }
    }
}
