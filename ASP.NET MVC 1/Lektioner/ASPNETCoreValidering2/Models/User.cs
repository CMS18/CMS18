using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreValidering2.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        [RegularExpression("^[A-Za-z0-9]$")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [RegularExpression(@"^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Range(1, 150)]
        public int Age { get; set; }
        [StringLength(150)]
        public string Description { get; set; }


    }
}
