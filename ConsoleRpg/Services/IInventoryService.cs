using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;

public interface IInventoryService
{
    void DisplayInventory();
    void AddItemToInventory(Item item);
    void RemoveItemFromInventory(Item item);
    Item GetRandomItemFromInventory();
    void InitializeInventory(Player currentPlayer);
}
