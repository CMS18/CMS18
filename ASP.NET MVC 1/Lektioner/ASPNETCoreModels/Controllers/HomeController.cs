using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreModels.Models;

namespace ASPNETCoreModels.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Student model = new Student("Lisa", "lisa@student.edu", "0709299090");

            return View(model);
        }

        public IActionResult StudentList()
        {
            List<Student> list = new List<Student>();
            list.Add(new Student("Lisa", "lisa@student.edu", "0709299090"));
            list.Add(new Student("Kalle", "kalle@student.edu", "0709299090"));
            list.Add(new Student("Eric", "eric@student.edu", "0709299090"));


            return View(list);
        }
    }
}