using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Webshop.Data;
using Webshop.Models.Entities;

namespace Webshop.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Refreshtoken> Refreshtokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyOrder>().HasBaseType<Order>();
            modelBuilder.Entity<SellOrder>().HasBaseType<Order>();
            modelBuilder.Entity<OrderItem>().HasBaseType<Product>();

            //Seeding some data
            SeedingData.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}