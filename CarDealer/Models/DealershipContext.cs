using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class DealershipContext: DbContext
    {
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Buyer> Buyer { get; set; }
        public DbSet<Salesperson> Salesperson { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BFHGHRM\SQLEXPRESS;Database=CarDealerDb;Trusted_Connection=True;");
        }
    }
}
