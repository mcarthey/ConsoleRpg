using ConsoleRpg.Context;
using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Dao;

public class PlayerRepository
{
    private readonly RpgContext _context;

    public PlayerRepository(RpgContext context)
    {
        _context = context;
    }

    public Player GetPlayer()
    {
        return _context.Characters.OfType<Player>().FirstOrDefault() ?? throw new Exception("Player not loaded.");
    }

    public void ResetPlayer(Player player)
    {
        player.Health = 100; // Reset health to initial value
        player.Inventory.Items.Clear(); // Clear inventory
        // Reset other attributes as needed...

        _context.SaveChanges(); // Save changes to the database
    }
}

