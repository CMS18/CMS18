using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tentamen.Models
{
    public class NewBook
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Title must contain between 1 and 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Author must contain between 1 and 50 characters")]
        public string Author { get; set; }

        [Range(0, 10000)]
        public int Pages { get; set; }

        public int CateogryId { get; set; }

        public string CategoryName { get; set; }

        public string StockValue { get; set; }


    }
}
