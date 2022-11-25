using CarDealer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Controllers
{
    public class SalespersonController : Controller
    {
        public IActionResult Index()
        {
            List<Salesperson> salespeople;
            using (var _context = new DealershipContext())
            {
                salespeople = _context.Salesperson.OrderBy(x => x.FirstName).ToList();
            }
            return View(salespeople);
        }

        public IActionResult Create()
        {
            Salesperson salesperson = new Salesperson();
            return View("SalespersonForm", salesperson);
        }

        public IActionResult Edit(int id)
        {
            Salesperson model;
            using (var _context = new DealershipContext())
            {
                model = _context.Salesperson.Single(x => x.SalespersonID == id);
            }
            return View("SalespersonForm", model);
        }

        public IActionResult Details(int id)
        {
            Salesperson model;
            using (var _context = new DealershipContext())
            {
                model = _context.Salesperson.Single(x => x.SalespersonID == id);
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Salesperson model;
            using (var _context = new DealershipContext())
            {
                model = _context.Salesperson.Single(x => x.SalespersonID == id);
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult Save(Salesperson model)
        {
            if(!ModelState.IsValid)
            {
                return View("SalespersonForm", model);
            }

            using (var _context = new DealershipContext())
            {
                if(model.SalespersonID == 0)
                {
                    _context.Salesperson.Add(model);
                }
                else
                {
                    var modelInDb = _context.Salesperson.
                        Single(x => x.SalespersonID == model.SalespersonID);

                    modelInDb.FirstName = model.FirstName;
                    modelInDb.LastName = model.LastName;
                    modelInDb.HireDate = model.HireDate;
                    modelInDb.Email = model.Email;
                    modelInDb.Salary = model.Salary;
                }
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Salesperson model)
        {
            using (var _context = new DealershipContext())
            {
                _context.Salesperson.Remove(model);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
