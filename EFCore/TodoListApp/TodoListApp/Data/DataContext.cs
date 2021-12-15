using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
