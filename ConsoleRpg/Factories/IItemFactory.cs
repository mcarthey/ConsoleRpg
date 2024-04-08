using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Factories;

public interface IItemFactory
{
    IValuable CreateValuableItem(int value, ValuableType type);
}