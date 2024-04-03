using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Services;

public class ItemManagementService<T> : IItemManagementService<T> where T : Item
{
    public ItemManagementService()
    {
    }

    public void PerformAction(T item)
    {
        switch (item)
        {
            case IBreakable breakableItem:
                breakableItem.Damage(1);
                break;
            case IDrinkable drinkableItem:
                drinkableItem.Drink();
                break;
            case ILootable lootableItem:
                lootableItem.Loot();
                break;
            case ISellable sellableItem:
                sellableItem.Sell();
                break;
            default:
                throw new InvalidOperationException("Unsupported item type.");
        }
    }
}