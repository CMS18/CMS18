using System.ComponentModel.DataAnnotations;

namespace Bank.Logic.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}