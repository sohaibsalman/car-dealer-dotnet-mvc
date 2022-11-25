using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        
        [Required]
        public string Manufacturer { get; set; }
        
        [Required]
        public string Model { get; set; }
        
        public string Type { get; set; }
        
        public int? Capacity { get; set; }
        
        public string Color { get; set; }
        
        [Required]
        public double Mileage { get; set; }
        
        [Required]
        public int Year { get; set; }
        
        [Display(Name = "Listing Price")]
        public double? ListingPrice { get; set; }
        
        public bool? Sold { get; set; }

        [NotMapped]
        public string VehicleInfo
        {
            get
            {
                return string.Format("{0} {1} {2}", Year, Manufacturer, Model);
            }
        }
    }
}
