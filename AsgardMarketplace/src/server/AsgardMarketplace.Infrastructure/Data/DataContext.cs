using AsgardMarketplace.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AsgardMarketplace.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
