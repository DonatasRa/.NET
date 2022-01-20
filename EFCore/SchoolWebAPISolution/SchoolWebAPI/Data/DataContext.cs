using Microsoft.EntityFrameworkCore;
using SchoolWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebAPI.Data
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
