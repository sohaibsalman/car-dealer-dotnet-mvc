using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        
        [Required]
        [Display(Name = "Sale Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime SaleDate { get; set; }
        
        [Required]
        [Display(Name = "Sale Price")]
        public double SalePrice { get; set; }

        public Buyer Buyer { get; set; }
        
        [Display(Name = "Buyer")]
        public int BuyerID { get; set; }

        public Salesperson Salesperson { get; set; }
        
        [Display(Name = "Salesperson")]
        public int SalespersonID { get; set; }

        public Vehicle Vehicle { get; set; }
        
        [Display(Name = "Vehicle")]
        public int VehicleID { get; set; }
    }
}
