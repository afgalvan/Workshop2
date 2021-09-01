using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Workshop2.Console.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<App>();
        }

        public static void AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            // Inject dependencies
        }
    }
}
