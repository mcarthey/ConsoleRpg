using ConsoleRpg.Entities;

namespace ConsoleRpg;

class Program
{
    static void Main(string[] args)
    {
        var seeder = new DatabaseSeeder(new RpgContext());
        seeder.SeedDatabase();
        var game = new Game();
        game.Start();

    }


}