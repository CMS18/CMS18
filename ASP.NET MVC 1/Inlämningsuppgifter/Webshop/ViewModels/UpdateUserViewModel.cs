using Webshop.IdentityData;
using Webshop.Models;

namespace Webshop.ViewModels
{
    public class UpdateUserViewModel
    {
        public AspNetUsers Users { get; set; }
        public ApplicationUser AppUser { get; set; }
    }
}