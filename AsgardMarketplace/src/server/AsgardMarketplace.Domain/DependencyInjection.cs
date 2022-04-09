using AsgardMarketplace.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AsgardMarketplace.Domain
{
    public static class DependencyInjection
    {
        public static void ConfigureDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<OrderService>();
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}