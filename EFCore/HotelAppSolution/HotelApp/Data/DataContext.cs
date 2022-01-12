using HotelApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Cleaner> Cleaners { get; set; }

        public DbSet<City> Cities { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
