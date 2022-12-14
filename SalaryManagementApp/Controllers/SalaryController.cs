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

    public class SalaryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public SalaryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult SalarySettings()
        {
            IEnumerable<Salary> objInventoryList = _db.Salaries.ToList();

            return View(objInventoryList);
        }

        

        //GET
        public IActionResult SalaryAdd()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SalaryAdd(Salary obj)
        {
            if (ModelState.IsValid)
            {
            _db.Salaries.Add(new Models.Salary { Tax = obj.Tax, SalaryFrom = obj.SalaryFrom, SalaryTo = obj.SalaryTo, YearlyBonusPercentage = obj.YearlyBonusPercentage });
                _db.SaveChanges();
                TempData["success"] = "Salary added successfully";
                return RedirectToAction("SalarySettings");
            }
            return View(obj);
        }

        //GET
        public IActionResult SalaryDelete(int? SId)
        {
            if (SId == null || SId == 0)
            {
                return NotFound();
            }
            var inventoryFromDb = _db.Salaries.Find(SId);

            if (inventoryFromDb == null)
            {
                return NotFound();
            }

            return View(inventoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult SalaryDeletePOST(int? SId)
        {
            
            var obj = _db.Salaries.Find(SId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Salaries.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("SalarySettings");
        }


    //GET
    public IActionResult SalaryEdit(int? SId)
    {
        if (SId == null || SId == 0)
        {
            return NotFound();
        }
        var inventoryFromDb = _db.Salaries.Find(SId);

        if (inventoryFromDb == null)
        {
            return NotFound();
        }

        return View(inventoryFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SalaryEdit(Salary obj)
    {
        if (ModelState.IsValid)
        {
            _db.Salaries.Where(x => obj.SId == x.SId).First().SalaryFrom = obj.SalaryFrom;
            _db.Salaries.Where(x => obj.SId == x.SId).First().SalaryTo = obj.SalaryTo;
            _db.Salaries.Where(x => obj.SId == x.SId).First().Tax = obj.Tax;
            _db.Salaries.Where(x => obj.SId == x.SId).First().YearlyBonusPercentage = obj.YearlyBonusPercentage;


            _db.SaveChanges();
            TempData["success"] = "Salary Edited successfully";
            return RedirectToAction("SalarySettings");
        }
        return View(obj);
    }
}


