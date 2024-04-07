using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Effects;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Models.Items;

public class Potion : DrinkableItem
{
    public int Duration { get; set; }
    public string Color { get; set; }
    public virtual List<Effect> Effects { get; set; }

    public override void PerformAction(Character character)
    {
        Drink(character);
    }

    public override void Drink(Character character)
    {
        base.Drink(character);

        foreach (var effect in Effects)
        {
            effect.Apply(character);
        }
    }

}