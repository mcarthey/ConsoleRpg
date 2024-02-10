using ConsoleRpg.Entities;
using ConsoleRpg.Services;
using ConsoleRpg;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddTransient<Game>();
    }
}
