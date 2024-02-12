using ConsoleRpg.Commands;
using ConsoleRpg.Context;
using ConsoleRpg.Services;
using ConsoleRpg.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ConsoleRpg;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<Game>();
        services.AddDbContext<RpgContext>();
        services.AddTransient<DatabaseSeeder>();

        // Register IServiceProvider
        services.AddSingleton<IServiceProvider>(services.BuildServiceProvider());

        // Register services
        services.AddTransient<PlayerService>();
        services.AddTransient<LocationService>();
        services.AddTransient<MerchantService>();
        services.AddTransient<CombatService>();
        services.AddTransient<QuestService>();
        services.AddScoped<InventoryService>();

        // Register command related classes
        services.AddTransient<CommandRegistry>();
        services.AddTransient<CommandParser>();
        services.AddTransient<CommandService>();

        // Register new command classes
        services.AddTransient<MoveToLocationCommand>();
        services.AddTransient<CheckInventoryCommand>();
        services.AddTransient<AttackEnemiesCommand>();
        services.AddTransient<DisplayVisitMessageCommand>();
        services.AddTransient<ViewCurrentQuestsCommand>();
        services.AddTransient<PickUpQuestCommand>();
        services.AddTransient<SavePlayerAndQuitCommand>();

        // Create Logs directory if it doesn't exist
        Directory.CreateDirectory("Logs");

        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        // Add logging services
        services.AddLogging(config =>
        {
            config.ClearProviders();
            config.AddSerilog();
        });
    }

}
