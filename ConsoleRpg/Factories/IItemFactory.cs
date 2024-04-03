using ConsoleRpg.Models.Items.Types;

public interface IItemFactory
{
    IValuable CreateValuableItem(int value, ValuableType type);
}