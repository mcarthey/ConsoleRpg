using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;

public class InventoryService
{
    public void DisplayInventory(Player player)
    {
        Console.WriteLine("Inventory:");
        foreach (var item in player.Inventory)
        {
            Console.WriteLine($"{item.Name}: {item.Description}");
        }
    }

    public void AddItemToInventory(Player player, Item item)
    {
        player.Inventory.Add(item);
        Console.WriteLine($"{item.Name} has been added to your inventory.");
    }

    public void RemoveItemFromInventory(Player player, Item item)
    {
        if (player.Inventory.Contains(item))
        {
            player.Inventory.Remove(item);
            Console.WriteLine($"{item.Name} has been removed from your inventory.");
        }
        else
        {
            Console.WriteLine($"{item.Name} is not in your inventory.");
        }
    }
}
