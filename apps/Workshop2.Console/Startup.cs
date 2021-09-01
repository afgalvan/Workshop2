using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop2.Console.Extensions;

namespace Workshop2.Console
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedServices();
            services.AddApplicationServices(Configuration);
        }
    }
}
