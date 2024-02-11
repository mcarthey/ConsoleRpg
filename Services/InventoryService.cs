using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;

public class InventoryService
{
    public void DisplayInventory(Player player)
    {
        CustomConsole.Info("Inventory:");
        foreach (var item in player.Inventory)
        {
            CustomConsole.Info($"{item.Name}: {item.Description}");
        }
    }

    public void AddItemToInventory(Player player, Item item)
    {
        player.Inventory.Add(item);
        CustomConsole.Info($"{item.Name} has been added to your inventory.");
    }

    public void RemoveItemFromInventory(Player player, Item item)
    {
        if (player.Inventory.Contains(item))
        {
            player.Inventory.Remove(item);
            CustomConsole.Info($"{item.Name} has been removed from your inventory.");
        }
        else
        {
            CustomConsole.Info($"{item.Name} is not in your inventory.");
        }
    }
}
