using ConsoleRpg.Context;
using ConsoleRpg.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleRpg;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<RpgContext>();
        services.AddTransient<DatabaseSeeder>();
        services.AddTransient<PlayerService>();
        services.AddTransient<LocationService>();
        services.AddTransient<MerchantService>();
        services.AddTransient<CombatService>();
        services.AddTransient<QuestService>();
        services.AddScoped<InventoryService>();
        services.AddTransient<Game>();
    }
}