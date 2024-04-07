using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Services;

public interface IItemManagementService<in T> where T : Item
{
    void PerformAction(T item, Character character);

    void AddValue(int amount, int inventoryId, ValuableType type);

    void SubtractValue(int amount, int inventoryId, ValuableType type);

    int GetValue(int inventoryId, ValuableType type);
}