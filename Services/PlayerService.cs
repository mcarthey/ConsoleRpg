using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using Spectre.Console;

namespace ConsoleRpg.Services;

public class PlayerService
{
    private readonly RpgContext _context;
    private readonly Player _player;
    private readonly InventoryService _inventoryService;

    public PlayerService(RpgContext context, InventoryService inventoryService)
    {
        _context = context;
        _player = LoadOrCreatePlayer();
        _inventoryService = inventoryService;
    }

    public void CheckInventory()
    {
        _inventoryService.DisplayInventory(_player);
    }

    public Player GetPlayer()
    {
        return _player ?? throw new Exception("Player not loaded.");
    }

    public void ResetPlayer(Player player)
    {
        player.Health = 100; // Reset health to initial value
        player.Gold = 0; // Reset gold to initial value
        player.Inventory.Clear(); // Clear inventory
        // Reset other attributes as needed...

        CustomConsole.Error("You have died... upsetting but resetting");
   
        _context.SaveChanges(); // Save changes to the database
    }

    public void SavePlayer()
    {
        _context.SaveChanges();
    }

    public void ShowActiveQuests()
    {
        var player = GetPlayer();
        var activeQuests = _context.Quests.Where(q => q.Players.Any(p => p.Id == player.Id) && !q.IsCompleted).ToList();

        if (activeQuests.Count == 0)
        {
            CustomConsole.Info("You have no active quests.");
        }
        else
        {
            CustomConsole.Notice("Your active quests:");
            foreach (var quest in activeQuests)
            {
                CustomConsole.Info($"{quest.Name}: {quest.Description}");
                quest.DisplayProgress();
            }
        }
    }

    public void ShowInventory()
    {
        _inventoryService.DisplayInventory(_player);
    }

    public void ViewCurrentQuests()
    {
        CustomConsole.Notice("Viewing current quests...");
        ShowActiveQuests();
    }

    // LoadOrCreatePlayer, ShowInventory, SavePlayer methods go here...
    private Player LoadOrCreatePlayer()
    {
        var player = _context.Players.FirstOrDefault();
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
}
