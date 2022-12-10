using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryManagementApp.Models;

namespace SalaryManagementApp.Controllers
{
    public class LoginController : Controller
    {
        

        // GET
        public IActionResult Login()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Login(Account a)
        {
            return View(a);
        }

        // GET
        public IActionResult SignUp()
        {
            return View();
        }

        //POST
        public IActionResult SignUp(Account a)
        {
            return View(a);
        }
    }
}

