using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Characters
{
    public class Enemy : Character
    {
        public int? QuestId { get; set; } // Foreign key property
        public virtual Quest? Quest { get; set; } // Navigation property
    }
}
