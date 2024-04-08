using ConsoleRpg.Entities;

namespace ConsoleRpg.Dao;

public interface IInventoryRepository
{
    Inventory GetInventory(int playerId);
    void AddItem(Item item, int inventoryId);
    void RemoveItem(Item item, int inventoryId);
    Item GetRandomItem(int inventoryId);
    // Add other methods as needed...
}