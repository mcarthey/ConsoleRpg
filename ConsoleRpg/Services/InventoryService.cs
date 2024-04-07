using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Services;

public class InventoryService : IInventoryService
{
    private readonly ISessionService _sessionService;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly Inventory _inventory;

    public InventoryService(ISessionService sessionService, IInventoryRepository inventoryRepository)
    {
        _sessionService = sessionService;
        _inventoryRepository = inventoryRepository;

        _inventory = _inventoryRepository.GetInventory(_sessionService.CurrentPlayer.Id);
    }

    public void DisplayInventory()
    {
        CustomConsole.Info("Inventory:");
        foreach (var item in _inventory.Items)
        {
            item.Display();
            //CustomConsole.Info($"{item.Name}: {item.Description}");
        }
    }

    public void AddItemToInventory(Item item)
    {
        _inventoryRepository.AddItem(item, _inventory.Id);
        CustomConsole.Info($"{item.Name} has been added to your inventory.");
    }

    public void RemoveItemFromInventory(Item item)
    {
        _inventoryRepository.RemoveItem(item, _inventory.Id);
        CustomConsole.Info($"{item.Name} has been removed from your inventory.");
    }

    //  get random item from inventory
    public Item GetRandomItemFromInventory()
    {
        return _inventoryRepository.GetRandomItem(_inventory.Id);
    }

    public void InitializeInventory(Player currentPlayer)
    {
        currentPlayer.Inventory ??= new Inventory();    
    }

    public Item GetItem(string itemName)
    {
        return _inventoryRepository.GetInventory(_sessionService.CurrentPlayer.Id).Items.FirstOrDefault(item => item.Name == itemName);
    }

    public void RemoveItem(Item item)
    {
        _inventoryRepository.RemoveItem(item, _inventory.Id);
    }
}