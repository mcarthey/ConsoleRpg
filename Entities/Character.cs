// Character.cs
namespace ConsoleRpg.Entities
{
    public abstract class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public int Damage { get; set; }
        public int Experience { get; set; }
    }
}
