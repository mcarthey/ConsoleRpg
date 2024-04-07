using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Items.Effects;

public class AttackEffect : Effect
{
    public override string Type => "Attack";

    public override void Apply(Character character)
    {
        character.Attack += Value;
    }
}