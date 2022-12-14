using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryManagementApp.Models;
using SalaryManagementApp.Data;
using System.Security.Cryptography;

namespace SalaryManagementApp.Controllers;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _db;

    public EmployeeController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET
    public IActionResult EmployeeAdd()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EmployeeAdd(Employee obj)
    {
        var salary = obj.Salary;
        var selectedSalaryObject = _db.Salaries.Where(x => x.SalaryFrom < salary && x.SalaryTo > salary).FirstOrDefault();
        if (selectedSalaryObject == null)
        {
            return NotFound();
        }

        var netSalary = obj.Salary * (100 - selectedSalaryObject.Tax) / 100;

        var bonus = netSalary * selectedSalaryObject.YearlyBonusPercentage / 100;

        var total = obj.Salary + bonus;


        if (ModelState.IsValid)
        {
            _db.Employees.Add(new Models.Employee { Name = obj.Name, Address = obj.Address, DOB = obj.DOB, Designation = obj.Designation, Salary = obj.Salary, NetSalary = netSalary, TotalSalary = total, Bonus = bonus });
            _db.SaveChanges();
            TempData["success"] = "Employee added successfully";
            return RedirectToAction("EmployeeHome");
        }
        return View(obj);
    }

    //GET
    public IActionResult EmployeeHome()
    {
        IEnumerable<Employee> objInventoryList = _db.Employees.ToList();

        return View(objInventoryList);

    }

    //GET
    public IActionResult EmployeeEdit(int? EId)
    {
        if (EId == null || EId == 0)
        {
            return NotFound();
        }
        var inventoryFromDb = _db.Employees.Find(EId);

        if (inventoryFromDb == null)
        {
            return NotFound();
        }

        return View(inventoryFromDb);
    }


    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EmployeeEdit(Employee obj)
    {
        if (ModelState.IsValid)
        {
            _db.Employees.Where(x => obj.EId == x.EId).First().Name = obj.Name;
            _db.Employees.Where(x => obj.EId == x.EId).First().Address = obj.Address;
            _db.Employees.Where(x => obj.EId == x.EId).First().DOB = obj.DOB;
            _db.Employees.Where(x => obj.EId == x.EId).First().Designation = obj.Designation;
            _db.Employees.Where(x => obj.EId == x.EId).First().Salary = obj.Salary;


            _db.SaveChanges();
            TempData["success"] = "Employee Edited successfully";
            return RedirectToAction("EmployeeHome");
        }
        return View(obj);
    }

    //GET
    public IActionResult EmployeeDelete(int? EId)
    {
        if (EId == null || EId == 0)
        {
            return NotFound();
        }
        var inventoryFromDb = _db.Employees.Find(EId);

        if (inventoryFromDb == null)
        {
            return NotFound();
        }

        return View(inventoryFromDb);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult EmployeeDeletePOST(int? EId)
    {

        var obj = _db.Employees.Find(EId);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Employees.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("EmployeeHome");
    }

    //GET
    public IActionResult EmployeeInfo(int? EId)
    {
        if (EId == null || EId == 0)
        {
            return NotFound();
        }
        var inventoryFromDb = _db.Employees.Find(EId);

        if (inventoryFromDb == null)
        {
            return NotFound();
        }

        return View(inventoryFromDb);
    }
}


