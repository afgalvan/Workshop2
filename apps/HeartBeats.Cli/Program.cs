using System.Threading.Tasks;
using HeartBeats.Cli.Settings;
using Microsoft.Extensions.Hosting;

namespace HeartBeats.Cli
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                    new Startup(Configuration.Startup).ConfigureServices(services)
                );
        }
    }
}
