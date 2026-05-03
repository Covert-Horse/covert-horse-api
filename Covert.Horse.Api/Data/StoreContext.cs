using Microsoft.EntityFrameworkCore;
using Covert.Horse.Domain.Catalog;
using Covert.Horse.Domain.Order; 

namespace Covert.Horse.Api.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item {
                    Id = 1,
                    Name = "Shirt",
                    Description = "Cool shirt",
                    Brand = "Nike",
                    Price = 29.99m
                },
                new Item {
                    Id = 2,
                    Name = "Pants",
                    Description = "Nice pants",
                    Brand = "Adidas",
                    Price = 49.99m
                }
            );
        }
    }
}