using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebApiEF.Models;

namespace SalesWebApiEF.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext (DbContextOptions<SalesContext> options)
            : base(options) {
        }

        public DbSet<SalesWebApiEF.Models.Customer> Customer { get; set; }

        public DbSet<SalesWebApiEF.Models.Order> Order { get; set; }

        public DbSet<SalesWebApiEF.Models.Orderline> Orderline { get; set; }

        public DbSet<SalesWebApiEF.Models.Product> Product { get; set; }


        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Customer>(e => {
                e.HasIndex(x => x.Code).IsUnique();
            });
        }
    }
}
