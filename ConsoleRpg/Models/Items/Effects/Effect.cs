using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Items.Effects;

public abstract class Effect
{
    public int Id { get; set; }
    public abstract string Type { get; }
    public int Value { get; set; }
    public int Duration { get; set; }

    public abstract void Apply(Character character);
}