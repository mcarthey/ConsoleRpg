using ConsoleRpg.Commands;
using ConsoleRpg.Context;
using ConsoleRpg.Dao;
using ConsoleRpg.Entities;
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
        services.AddTransient<ICombatService, CombatService>();
        services.AddTransient<ICommandService, CommandService>();
        services.AddTransient<IInventoryService, InventoryService>();
        //services.AddTransient<IItemManagementService<Item>, ItemManagementService<Item>>();
        services.AddTransient(typeof(IItemManagementService<>), typeof(ItemManagementService<>));
        services.AddTransient<ILocationService, LocationService>();
        services.AddTransient<IMerchantService, MerchantService>();
        services.AddTransient<IPlayerService, PlayerService>();
        services.AddTransient<IQuestService, QuestService>();
        services.AddTransient<ISessionService, SessionService>();

        services.AddTransient<PlayerService>();
        services.AddTransient<LocationService>();
        services.AddTransient<MerchantService>();
        services.AddTransient<CombatService>();
        services.AddTransient<QuestService>();
        services.AddTransient<InventoryService>();
        services.AddScoped<SessionService>();

        // Register command related classes
        services.AddTransient<CommandRegistry>();
        services.AddTransient<CommandParser>();
        services.AddTransient<CommandService>();

        // Register new command classes
        services.AddTransient<MoveToLocationCommand>();
        services.AddTransient<CheckInventoryCommand>();
        services.AddTransient<AttackEnemiesCommand>();
        services.AddTransient<VisitMerchantCommand>();
        services.AddTransient<ViewCurrentQuestsCommand>();
        services.AddTransient<PickUpQuestCommand>();
        services.AddTransient<SavePlayerAndQuitCommand>();

        // Register repositories
        services.AddScoped<PlayerRepository>();
        services.AddScoped<SessionRepository>();
        services.AddScoped<LocationRepository>();
        services.AddScoped<MerchantRepository>();

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
