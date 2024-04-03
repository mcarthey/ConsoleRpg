using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Items.Effects;

public class HealEffect : Effect
{
    public override string Type => "Heal";

    public override void Apply(Character character)
    {
        character.Health = Math.Min(character.MaxHealth, character.Health + Value);
    }
}