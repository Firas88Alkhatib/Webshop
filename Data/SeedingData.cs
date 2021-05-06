using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;
using Webshop.Models.Entities;

namespace Webshop.Data
{
    public static class SeedingData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var images = new List<Image> {
                new Image { Id = 1, ProductId = 1, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 2, ProductId = 1, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 3, ProductId = 2, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 4, ProductId = 2, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 5, ProductId = 3, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 6, ProductId = 4, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 7, ProductId = 4, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 8, ProductId = 4, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 9, ProductId = 5, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 10, ProductId = 6, Url = "https://source.unsplash.com/user/c_v_r" },
                new Image { Id = 11, ProductId = 7, Url = "https://source.unsplash.com/user/c_v_r" },
            };

            var categories = new List<Category> {
                new Category { Id = 1, Name = "Chargers" },
                new Category { Id = 2, Name = "Mobile Accessories" },
                new Category { Id = 3, Name = "Clothes"},
                new Category { Id = 4, Name = "Home appliance"},
                new Category { Id = 5, Name = "Garden"},
                new Category { Id = 6, Name = "Flowers"},
            };

            var joins = new[] {
                new { ProductsId = 1, CategoriesId = 1 },
                new { ProductsId = 1, CategoriesId = 2 },
                new { ProductsId = 2, CategoriesId = 3 },
                new { ProductsId = 3, CategoriesId = 4 },
                new { ProductsId = 4, CategoriesId = 5 },
                new { ProductsId = 4, CategoriesId = 6 },
                new { ProductsId = 5, CategoriesId = 4 },
                new { ProductsId = 6, CategoriesId = 3 },
                new { ProductsId = 7, CategoriesId = 2 },

            }.ToList();

            var products = new List<Product> {
                new Product{ Id = 1, Name = "Phone Charger", Description = "Type-C Phone Charger with Fast-Charging support", Price = 24.99m,CostPrice = 17.25m},
                new Product{ Id = 2, Name = "T-Shirt", Description = "A T-Shirt for hot summer", Price = 17.39m, CostPrice= 9.21m},
                new Product{ Id = 3, Name = "Washing Machine", Description = "Washing machine with 1700 rpm", Price = 399,CostPrice= 296.10m},
                new Product{ Id = 4, Name = "Dahlia seeds", Description = "Dahlia plant seeds to decorate your garden",Price= 2.45m, CostPrice =0.77m},
                new Product{ Id = 5, Name = "LED 4K TV", Description = "LED TV with Android OS with 4K", Price = 429, CostPrice=320},
                new Product{ Id = 6, Name = "Winter Jacket", Description = "Winter jacket with water proof technology",Price = 56, CostPrice= 29.61m},
                new Product{ Id = 7, Name = "Earphones", Description = "Wireless earphone with long ",Price = 27.54m, CostPrice = 8.2m},
            };

            modelBuilder.Entity("CategoryProduct").HasData(joins);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Image>().HasData(images);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
