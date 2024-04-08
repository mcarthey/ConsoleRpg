using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Services;

public interface IInventoryService
{
    void DisplayInventory();
    void AddItemToInventory(Item item);
    void RemoveItemFromInventory(Item item);
    Item GetRandomItemFromInventory();
    void InitializeInventory(Player currentPlayer);
    Item GetItem(string itemName);
    void RemoveItem(Item item);
}