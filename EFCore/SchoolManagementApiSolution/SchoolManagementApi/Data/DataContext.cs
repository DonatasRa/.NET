using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Models;

namespace SchoolManagementApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        
        public DbSet<Student> Students { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
