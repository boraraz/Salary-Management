using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryManagementApp.Data;
using SalaryManagementApp.Models;

namespace SalaryManagementApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Login()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Login(Account obj)
        {
            var mail = obj.Mail;
            var selectedAccount = _db.Accounts.Where(x => x.Password == obj.Password).FirstOrDefault();
            if(selectedAccount == null)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("HomePage", "HomePage");

        }

        // GET
        public IActionResult SignUp()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult SignUp(Account obj)
        {

            if (ModelState.IsValid)
            {
                _db.Accounts.Add(new Models.Account { Name = obj.Name, Mail = obj.Mail, Password = obj.Password });
                _db.SaveChanges();
                TempData["success"] = "Account created successfully";
                return RedirectToAction("Login");
            }
            return View(obj);
        }
    }
}

