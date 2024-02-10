using ConsoleRpg.Entities;

namespace ConsoleRpg.Services;

public class PlayerService
{
    private RpgContext _context;
    private Player _player;

    public PlayerService(RpgContext context)
    {
        _context = context;
        _player = LoadOrCreatePlayer();
    }

    // LoadOrCreatePlayer, ShowInventory, SavePlayer methods go here...
    private Player LoadOrCreatePlayer()
    {
        Player player = _context.Players.FirstOrDefault();
        if (player == null)
        {
            player = new Player
            {
                Name = "Player",
                Description = "Some description", // Add this line
                Health = 100,
                Damage = 10,
                Gold = 0,
                Inventory = new List<Item>(),
                ActiveQuests = new List<Quest>()
            };
            _context.Players.Add(player);
            _context.SaveChanges();
        }
        return player ?? throw new Exception("Failed to load or create player.");
    }

    public Player GetPlayer()
    {
        return _player ?? throw new Exception("Player not loaded.");
    }

    public void ShowInventory()
    {
        Console.WriteLine("Inventory:");
        foreach (var item in _player.Inventory)
        {
            Console.WriteLine($"{item.Name}: {item.Description}");
        }
    }

    public void ShowActiveQuests()
    {
        var player = GetPlayer();
        if (player.ActiveQuests.Count == 0)
        {
            Console.WriteLine("You have no active quests.");
        }
        else
        {
            Console.WriteLine("Your active quests:");
            foreach (var quest in player.ActiveQuests)
            {
                Console.WriteLine($"{quest.Name}: {quest.Description}");
            }
        }
    }

    public void ResetPlayer(Player player)
    {
        player.Health = 100; // Reset health to initial value
        player.Gold = 0; // Reset gold to initial value
        player.Inventory.Clear(); // Clear inventory
        // Reset other attributes as needed...

        _context.SaveChanges(); // Save changes to the database
    }

    public void ViewCurrentQuests()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Viewing current quests...");
        Console.ResetColor();
        ShowActiveQuests();
    }

    public void CheckInventory()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Checking inventory...");
        Console.ResetColor();
        ShowInventory();
    }

    public void SavePlayer()
    {
        _context.SaveChanges();
    }

}