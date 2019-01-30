using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreValidering1.Models
{
    public class Person
    {
        [Required(ErrorMessage ="Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must contain between 2 and 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage = "Enter correct email")]
        [StringLength(50, ErrorMessage = "Email must contain max 50 characters")]
        public string Email { get; set; }
        

    }
}
