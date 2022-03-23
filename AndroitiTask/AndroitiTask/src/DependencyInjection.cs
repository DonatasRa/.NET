
using AndroitiTask.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AndroitiTask
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this ServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<CalculationService>();
            services.AddTransient<OutputService>();
        }
    }
}
