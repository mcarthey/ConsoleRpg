namespace ConsoleRpg.Entities;

public abstract class Character
{
    public int Attack { get; set; }
    public int Damage { get; set; }
    public string Description { get; set; }
    public int Experience { get; set; }
    public int Health { get; set; }
    public string Name { get; set; }
}
