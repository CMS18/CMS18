using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class UpdateUser
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter correct email")]
        public string Email { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}