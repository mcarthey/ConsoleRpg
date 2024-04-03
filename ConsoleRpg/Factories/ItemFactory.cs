using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.Types;

public class ItemFactory : IItemFactory
{
    public IValuable CreateValuableItem(int value, ValuableType type)
    {
        switch (type)
        {
            case ValuableType.Gold:
                return new Gold { Value = value };
            //case ValuableType.Gem:
            //    return new Gem { Value = value };
            //case ValuableType.Token:
            //    return new Token { Value = value };
            // Add other cases as needed...
            default:
                throw new ArgumentException("Unsupported valuable type.", nameof(type));
        }
    }
}
