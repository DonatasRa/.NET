using Microsoft.EntityFrameworkCore;
using SquaresApi.Models;

namespace SquaresApi.Data
{
    public class DataContext : DbContext
    {

        public DbSet<PointModel> Points { get; set; }

        public DbSet<PointList> PointLists { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PointList>()
                .HasMany(p => p.Points)
                .WithOne(pl => pl.PointList);
        }
    }
}
