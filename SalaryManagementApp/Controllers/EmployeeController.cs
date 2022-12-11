using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryManagementApp.Models;


namespace SalaryManagementApp.Controllers;

    public class EmployeeController : Controller
    {


        // GET
        public IActionResult EmployeeAdd()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult EmployeeAdd(Salary s)
        {
            return View();
        }

        //GET
        public IActionResult EmployeeHome()
        {
            return View();

        }
    }


