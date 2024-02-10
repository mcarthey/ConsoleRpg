namespace ConsoleRpg.Entities;

public class DialogueOption
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int NpcId { get; set; }
    public virtual Npc Npc { get; set; }
}
