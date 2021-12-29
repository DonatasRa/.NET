using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopListApp.Models;

namespace ShopListApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ShopItem> ShopItems { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<ShopItemTag> ShopItemTags { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopItemTag>()
                .HasKey(sit => new { sit.TagId, sit.ShopItemId });

            modelBuilder.Entity<Shop>()
                .HasData(
                    new Shop
                    {
                        Id = 1,
                        Name = "Skudurynas"
                    },
                    new Shop
                    {
                        Id = 2,
                        Name = "Krautuve"
                    });
            modelBuilder.Entity<ShopItem>()
                .HasData(
                    new ShopItem
                    {
                        Id = 1,
                        Name = "Kepure",
                        ShopId = 1,
                        ExpiryDate = DateTime.UtcNow,
                    },
                    new ShopItem
                    {
                        Id = 2,
                        Name = "Batai",
                        ShopId = 1,
                        ExpiryDate = DateTime.UtcNow,
                    },
                    new ShopItem
                    {
                        Id = 3,
                        Name = "Bulves",
                        ShopId = 2,
                        ExpiryDate = DateTime.UtcNow,
                    },
                    new ShopItem
                    {
                        Id = 4,
                        Name = "Morkos",
                        ShopId = 2,
                        ExpiryDate = DateTime.UtcNow,
                    },
                    new ShopItem
                    {
                        Id = 5,
                        Name = "Svogunai",
                        ShopId = 2,
                        ExpiryDate = DateTime.UtcNow,
                    });
        }
    }
}
