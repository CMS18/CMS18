using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        [RegularExpression("^[A-Za-z0-9]$")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [RegularExpression(@"^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter correct email")]
        public string Email { get; set; }

    }
}
