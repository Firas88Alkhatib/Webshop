using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Webshop.Data;

namespace Webshop.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyOrder>().HasBaseType<Order>();
            modelBuilder.Entity<SellOrder>().HasBaseType<Order>();
            modelBuilder.Entity<OrderItem>().HasBaseType<Product>();

            //Seeding some data
            SeedingData.Seed(modelBuilder);
        }
    }
}