using CoffeeListApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeListApp.Domain
{
    public static class DependencyInjection
    {
        public static void ConfigureDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CoffeeService>();
        }
    }
}
