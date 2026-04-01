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
    }
}