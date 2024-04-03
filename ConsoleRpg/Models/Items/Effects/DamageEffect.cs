using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Items.Effects;

public class DamageEffect : Effect
{
    public override string Type => "Damage";

    public override void Apply(Character character)
    {
        character.Health = Math.Max(0, character.Health - Value);
    }
}