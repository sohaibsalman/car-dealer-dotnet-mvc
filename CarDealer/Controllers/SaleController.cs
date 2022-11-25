using CarDealer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            List<Sale> sales;
            using (var _context = new DealershipContext())
            {
                sales = _context.Sale.
                    Include(x => x.Buyer).
                    Include(x => x.Salesperson).
                    Include(x => x.Vehicle).
                    OrderByDescending(x => x.SaleDate).
                    ToList();
            }
            return View(sales);
        }

        public IActionResult Edit(int id)
        {
            VehicleSaleViewModel viewModel = new VehicleSaleViewModel();
            using (var _context = new DealershipContext())
            {
                viewModel.Sale = _context.Sale.Single(x => x.SaleID == id);
                viewModel.Buyers = _context.Buyer.OrderBy(x => x.FirstName).ToList();
                viewModel.Salespeople = _context.Salesperson.ToList();
                viewModel.Vehicles = _context.Vehicle.OrderBy(x => x.Year).ToList();
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            Sale sale;
            using (var _context = new DealershipContext())
            {
                sale = _context.Sale.
                    Include(x => x.Buyer).
                    Include(x => x.Salesperson).
                    Include(x => x.Vehicle).
                    Single(x => x.SaleID == id);
            }
            return View(sale);
        }

        [HttpPost]
        public IActionResult Edit(Sale sale)
        {
            if(!ModelState.IsValid)
            {
                VehicleSaleViewModel viewModel = new VehicleSaleViewModel();
                using (var _context = new DealershipContext())
                {
                    viewModel.Sale = _context.Sale.Single(x => x.SaleID == sale.SaleID);
                    viewModel.Buyers = _context.Buyer.OrderBy(x => x.FirstName).ToList();
                    viewModel.Salespeople = _context.Salesperson.ToList();
                    viewModel.Vehicles = _context.Vehicle.OrderBy(x => x.Year).ToList();
                }
                return View(viewModel);
            }

            using (var _context = new DealershipContext())
            {
                var saleInDb = _context.Sale.
                    Include(x => x.Buyer).
                    Include(x => x.Salesperson).
                    Include(x => x.Vehicle).
                    Single(x => x.SaleID == sale.SaleID);

                saleInDb.BuyerID = sale.BuyerID;
                saleInDb.SalespersonID = sale.SalespersonID;
                saleInDb.VehicleID = sale.VehicleID;
                saleInDb.SaleDate = sale.SaleDate;
                saleInDb.SalePrice = sale.SalePrice;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Sale sale)
        {
            using (var _context = new DealershipContext())
            {
                _context.Remove(sale);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
