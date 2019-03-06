using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;
using Webshop.IdentityData;

namespace Webshop.ViewModels
{
    public class UpdateUserViewModel
    {
        public AspNetUsers Users { get; set; }
        public ApplicationUser AppUser { get; set; }
    }
}
