using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using ConsoleRpg.Utils;
using Microsoft.EntityFrameworkCore;

public class InventoryRepository : IInventoryRepository
{
    private readonly RpgContext _context;

    public InventoryRepository(RpgContext context)
    {
        _context = context;
    }

    public Inventory GetInventory(int playerId)
    {
        return _context.Characters
            .Include(c => c.Inventory)
            .ThenInclude(i => i.Items)
            .Single(c => c.Id == playerId)
            .Inventory;
    }

    public void AddItem(Item item, int inventoryId)
    {
        var inventory = _context.Inventories.Find(inventoryId);
        inventory.Items.Add(item);
        _context.SaveChanges();
    }

    public void RemoveItem(Item item, int inventoryId)
    {
        var inventory = _context.Inventories.Find(inventoryId);
        inventory.Items.Remove(item);
        _context.SaveChanges();
    }

    public Item GetRandomItem(int inventoryId)
    {
        var inventory = _context.Inventories.Find(inventoryId);
        var allItems = inventory.Items.ToList();
        int index = new Random().Next(allItems.Count);
        return allItems.ElementAt(index);
    }
}

public interface IInventoryRepository
{
    Inventory GetInventory(int playerId);
    void AddItem(Item item, int inventoryId);
    void RemoveItem(Item item, int inventoryId);
    Item GetRandomItem(int inventoryId);
    // Add other methods as needed...
}
