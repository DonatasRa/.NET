using Microsoft.EntityFrameworkCore;
using ShopWebApi.Models;

namespace ShopWebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }

        public DbSet<ShopItem> ShopItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }


}
