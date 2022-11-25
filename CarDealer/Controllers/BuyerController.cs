using CarDealer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Controllers
{
    public class BuyerController : Controller
    {
        public IActionResult Index()
        {
            List<Buyer> buyers;
            using (var _context = new DealershipContext())
            {
                buyers = _context.Buyer.OrderBy(x => x.FirstName).ToList();
            }
            return View(buyers);
        }

        public IActionResult Create()
        {
            Buyer buyer = new Buyer();
            return View("BuyerForm", buyer);
        }

        public IActionResult Edit(int id)
        {
            Buyer buyer;
            using (var _context = new DealershipContext())
            {
                buyer = _context.Buyer.Single(b => b.BuyerID == id);
            }
            return View("BuyerForm", buyer);
        }

        public IActionResult Details(int id)
        {
            BuyerViewModel viewModel = new BuyerViewModel();
            using (var _context = new DealershipContext())
            {
                viewModel.Buyer = _context.Buyer.Single(b => b.BuyerID == id);
                viewModel.Sales = _context.Sale.
                    Include(x => x.Vehicle).
                    OrderByDescending(x => x.SaleDate).
                    Where(x => x.BuyerID == id).
                    ToList();
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            Buyer buyer;
            using (var _context = new DealershipContext())
            {
                buyer = _context.Buyer.Single(b => b.BuyerID == id);
            }
            return View(buyer);
        }

        [HttpPost]
        public IActionResult Save(Buyer buyer)
        {
            if(!ModelState.IsValid)
            {
                return View("BuyerForm");
            }

            using (var _context = new DealershipContext())
            {
                if(buyer.BuyerID == 0)
                {
                    _context.Buyer.Add(buyer);
                }
                else
                {
                    Buyer buyerInDb = _context.Buyer.Single(b => b.BuyerID == buyer.BuyerID);

                    buyerInDb.FirstName = buyer.FirstName;
                    buyerInDb.LastName = buyer.LastName;
                    buyerInDb.PhoneNumber = buyer.PhoneNumber;
                    buyerInDb.Address = buyer.Address;
                    buyerInDb.City = buyer.City;
                    buyerInDb.State = buyer.State;
                    buyerInDb.Zip = buyer.Zip;
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Buyer buyer)
        {
            using (var _context = new DealershipContext())
            {
                _context.Buyer.Remove(buyer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}
