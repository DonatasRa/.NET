using Microsoft.Extensions.DependencyInjection;
using CoffeeListApp.Infrastructure;
using Microsoft.Extensions.Configuration;
using CoffeeListApp.Domain;

namespace CoffeeListApp.Application
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            serviceCollection.RegisterDatabase(connectionString);
            serviceCollection.ConfigureDomain();
        }
    }
}