using Microsoft.Extensions.DependencyInjection;
using CoffeeListApp.Data;
using CoffeeListApp.Domain.Interfaces;
using CoffeeListApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoffeeListApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DataContext>(d => d.UseSqlServer(connectionString));
            serviceCollection.AddTransient<ICoffeeRepository, CoffeeRepository>();
        }
    }
} 