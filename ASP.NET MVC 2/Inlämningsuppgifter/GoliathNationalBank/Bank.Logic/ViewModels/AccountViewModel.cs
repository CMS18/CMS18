using System.ComponentModel.DataAnnotations;

namespace Bank.Logic.ViewModels
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}