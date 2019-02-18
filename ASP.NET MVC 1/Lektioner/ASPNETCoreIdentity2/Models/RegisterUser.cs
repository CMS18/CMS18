using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreIdentity2.Models
{
    public class RegisterUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string RoleName { get; set; }



    }
}
