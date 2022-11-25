using CarDealer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            List<Vehicle> vehicles;
            using (var _context = new DealershipContext())
            {
                vehicles = _context.Vehicle.
                    Where(x => x.Sold == false).
                    OrderByDescending(x => x.ListingPrice).
                    ToList();
            }
            return View(vehicles);
        }

        public IActionResult Create()
        {
            Vehicle vehicle = new Vehicle();
            return View("VehicleForm", vehicle);
        }

        public IActionResult Edit(int id)
        {
            Vehicle vehicle;
            using (var _context = new DealershipContext())
            {
                vehicle = _context.Vehicle.Single(x => x.VehicleID == id);
            }
            return View("VehicleForm", vehicle);
        }
        
        public IActionResult Details(int id)
        {
            Vehicle vehicle;
            using (var _context = new DealershipContext())
            {
                vehicle = _context.Vehicle.Single(x => x.VehicleID == id);
            }
            return View(vehicle);
        }

        public IActionResult Delete(int id)
        {
            Vehicle vehicle;
            using (var _context = new DealershipContext())
            {
                vehicle = _context.Vehicle.Single(x => x.VehicleID == id);
            }
            return View(vehicle);
        }

        public IActionResult MarkSold(int id)
        {
            VehicleSaleViewModel viewModel = new VehicleSaleViewModel();
            viewModel.Sale = new Sale();

            using (var _context = new DealershipContext())
            {
                viewModel.Sale.Vehicle = _context.Vehicle.
                    Single(x => x.VehicleID == id);

                viewModel.Salespeople = _context.Salesperson.ToList();
                viewModel.Buyers = _context.Buyer.ToList();
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(Vehicle vehicle)
        {
            if(!ModelState.IsValid)
            {
                return View("VehicleForm", vehicle);
            }

            using (var _context = new DealershipContext())
            {
                if(vehicle.VehicleID == 0)
                {
                    vehicle.Sold = false;
                    _context.Vehicle.Add(vehicle);
                }
                else
                {
                    var vehicleInDb = _context.Vehicle.
                        Single(x => x.VehicleID == vehicle.VehicleID);

                    vehicleInDb.Manufacturer = vehicle.Manufacturer;
                    vehicleInDb.Model = vehicle.Model;
                    vehicleInDb.Type = vehicle.Type;
                    vehicleInDb.Capacity = vehicle.Capacity;
                    vehicleInDb.Color = vehicle.Color;
                    vehicleInDb.Mileage = vehicle.Mileage;
                    vehicleInDb.Year = vehicle.Year;
                    vehicleInDb.ListingPrice = vehicle.ListingPrice;

                }
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Vehicle vehicle)
        {
            using (var _context = new DealershipContext())
            {
                _context.Vehicle.Remove(vehicle);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkSold(Sale sale)
        {
            if(!ModelState.IsValid)
            {
                VehicleSaleViewModel viewModel = new VehicleSaleViewModel();
                viewModel.Sale = new Sale();

                using (var _context = new DealershipContext())
                {
                    viewModel.Sale.Vehicle = _context.Vehicle.
                        Single(x => x.VehicleID == sale.Vehicle.VehicleID);

                    viewModel.Salespeople = _context.Salesperson.ToList();

                    viewModel.Buyers = _context.Buyer.ToList();
                }

                return View(viewModel);
            }


            using (var _context = new DealershipContext())
            {
                sale.Vehicle = _context.Vehicle.
                    Single(x => x.VehicleID == sale.Vehicle.VehicleID);

                _context.Sale.Add(sale);

                var vehicleInDb = _context.Vehicle.
                    Single(x => x.VehicleID == sale.Vehicle.VehicleID);

                vehicleInDb.Sold = true;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
