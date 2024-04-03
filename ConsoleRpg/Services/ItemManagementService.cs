using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Services;

public class ItemManagementService<T> : IItemManagementService<T> where T : Item
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IItemFactory _itemFactory;

    public ItemManagementService(IInventoryRepository inventoryRepository, IItemFactory itemFactory)
    {
        _inventoryRepository = inventoryRepository;
        _itemFactory = itemFactory;
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

    public void AddValue(int amount, int inventoryId, ValuableType type)
    {
        var inventory = _inventoryRepository.GetInventory(inventoryId);
        var valuableItem = inventory.Items.OfType<IValuable>().FirstOrDefault(i => i.Type == type);
        if (valuableItem != null)
        {
            valuableItem.Value += amount;
        }
        else
        {
            var newItem = _itemFactory.CreateValuableItem(amount, type);
            _inventoryRepository.AddItem((T)newItem, inventoryId);
        }
    }

    public void SubtractValue(int amount, int inventoryId, ValuableType type)
    {
        var inventory = _inventoryRepository.GetInventory(inventoryId);
        var valuableItem = inventory.Items.OfType<IValuable>().FirstOrDefault(i => i.Type == type);
        if (valuableItem != null && valuableItem.Value >= amount)
        {
            valuableItem.Value -= amount;
        }
        else
        {
            throw new Exception("Not enough value.");
        }
    }

    public int GetValue(int inventoryId, ValuableType type)
    {
        var inventory = _inventoryRepository.GetInventory(inventoryId);
        var valuableItem = inventory.Items.OfType<IValuable>().FirstOrDefault(i => i.Type == type);
        return valuableItem?.Value ?? 0;
    }
}