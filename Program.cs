﻿using ConsoleRpg.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleRpg
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create service collection
            ServiceCollection serviceCollection = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(serviceCollection);

            // Create service provider
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            try
            {
                // Create a new scope
                using (var scope = serviceProvider.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    // Seed database
                    var seeder = services.GetRequiredService<DatabaseSeeder>();
                    seeder.SeedDatabase();

                    // Start game
                    services.GetRequiredService<Game>().Start();
                }
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An unhandled exception occurred.");
            }
        }
    }
}
