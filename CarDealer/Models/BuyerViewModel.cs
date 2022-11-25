using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class BuyerViewModel
    {
        public Buyer Buyer { get; set; }
        public IList<Sale> Sales { get; set; }
    }
}
