using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class VehicleSaleViewModel
    {
        public Sale Sale { get; set; }
        public List<Buyer> Buyers { get; set; }
        public List<Salesperson> Salespeople { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
