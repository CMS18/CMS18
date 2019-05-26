using System.ComponentModel.DataAnnotations;

namespace Bank.WebUI.Controllers
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}