using ConsoleRpg.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ConsoleRpg;

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

        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

        try
        {
            logger.LogInformation("Starting application");

            // Create a new scope
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Seed database
                logger.LogInformation("Seeding database");
                var seeder = services.GetRequiredService<DatabaseSeeder>();
                seeder.SeedDatabase();
                logger.LogInformation("Finished seeding database");

                // Start game
                logger.LogInformation("Getting required service to start game");
                var game = services.GetRequiredService<Game>();
                logger.LogInformation("Starting game"); 
                game.Start();
                logger.LogInformation("Finished game");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred.");
        }

        logger.LogInformation("Ending application");

        // Ensure all logs are flushed to the file
        Log.CloseAndFlush();
    }
}