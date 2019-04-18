using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

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