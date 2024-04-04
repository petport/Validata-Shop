using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopTest.Models;

namespace ValidataShopTest.DAL
{
    public class ValidataShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ValidataShopContext(DbContextOptions<ValidataShopContext> options) : base(options)
        {
        }

        public ValidataShopContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server = PETROS-DESKTOP\SQLEXPRESS;Initial Catalog=ValidataShop;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
