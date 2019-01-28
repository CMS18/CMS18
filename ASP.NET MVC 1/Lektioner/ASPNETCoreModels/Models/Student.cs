using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreModels.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Student(string name, string email, string phone)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;

        }
    }
}
