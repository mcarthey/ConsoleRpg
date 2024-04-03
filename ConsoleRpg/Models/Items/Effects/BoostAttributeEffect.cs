using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Items.Effects;

public class BoostAttributeEffect : Effect
{
    public override string Type => "BoostAttribute";

    public override void Apply(Character character)
    {
        // Logic to boost the attribute
    }
}