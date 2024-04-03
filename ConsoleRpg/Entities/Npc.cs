namespace ConsoleRpg.Entities;

public abstract class Npc
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<DialogueOption> DialogueOptions { get; set; }
    public virtual List<Quest> Quests { get; set; }
}