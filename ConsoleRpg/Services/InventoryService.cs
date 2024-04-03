using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Services;

public class InventoryService : IInventoryService
{
    private readonly ISessionService _sessionService;
    private readonly Inventory _inventory;

    public InventoryService(ISessionService sessionService)
    {
        _sessionService = sessionService;
        _inventory = _sessionService.CurrentPlayer.Inventory;
    }

    public void DisplayInventory()
    {
        CustomConsole.Info("Inventory:");
        foreach (var item in _inventory.Items)
        {
            CustomConsole.Info($"{item.Name}: {item.Description}");
        }
    }

    public void AddItemToInventory(Item item)
    {
        _inventory.Items.Add(item);
        CustomConsole.Info($"{item.Name} has been added to your inventory.");
    }

    public void RemoveItemFromInventory(Item item)
    {
        if (_inventory.Items.Contains(item))
        {
            _inventory.Items.Remove(item);
            CustomConsole.Info($"{item.Name} has been removed from your inventory.");
        }
        else
        {
            CustomConsole.Info($"{item.Name} is not in your inventory.");
        }
    }

    //  get random item from inventory
    public Item GetRandomItemFromInventory()
    {
        var allItems = _inventory.Items.ToList();
        int index = new Random().Next(allItems.Count);
        return allItems.ElementAt(index);
    }

    public void AddGold(int amount)
    {
        var gold = _inventory.Items.OfType<Gold>().FirstOrDefault();
        if (gold != null)
        {
            gold.Amount += amount;
        }
        else
        {
            _inventory.Items.Add(new Gold { Amount = amount });
        }
        CustomConsole.Info($"Player gains {amount} gold.");
    }

    public void SubtractGold(int amount)
    {
        var gold = _inventory.Items.OfType<Gold>().FirstOrDefault();
        if (gold != null && gold.Amount >= amount)
        {
            gold.Amount -= amount;
            CustomConsole.Info($"Player loses {amount} gold.");
        }
        else
        {
            throw new Exception("Not enough gold.");
        }
    }

    public int GetGoldAmount()
    {
        var gold = _inventory.Items.OfType<Gold>().FirstOrDefault();
        return gold?.Amount ?? 0;
    }

    public void InitializeInventory(Player currentPlayer)
    {
        currentPlayer.Inventory ??= new Inventory();    
    }
}