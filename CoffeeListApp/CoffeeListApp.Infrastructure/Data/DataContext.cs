using CoffeeListApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeListApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Coffee> Coffees { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
