namespace ConsoleRpg.Models.Items.Types;

public interface IValuable
{
    int Value { get; set; }
    ValuableType Type { get; }
}