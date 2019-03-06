using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Webshop.IdentityData
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

    }
}
