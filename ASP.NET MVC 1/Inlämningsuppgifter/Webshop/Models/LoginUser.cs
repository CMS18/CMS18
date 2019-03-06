using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    [Authorize]
    public class LoginUser
    {
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
