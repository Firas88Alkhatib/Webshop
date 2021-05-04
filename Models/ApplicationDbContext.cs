using Microsoft.EntityFrameworkCore;

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
        }
    }
}