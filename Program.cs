using ConsoleRpg.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleRpg
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create service collection
            ServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);

            // Create service provider
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            // Seed database
            var seeder = serviceProvider.GetService<DatabaseSeeder>();
            seeder.SeedDatabase();

            // Start game
            serviceProvider.GetService<Game>().Start();
        }
    }
}
