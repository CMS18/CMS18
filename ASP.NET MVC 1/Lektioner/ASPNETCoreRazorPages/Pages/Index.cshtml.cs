using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNETCoreRazorPages.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "För att logga in fyll i uppgifterna";
        }

        public void OnPost()
        {
            string user = Username;
            string pwd = Password;
        }
    }
}
