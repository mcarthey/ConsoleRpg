namespace ConsoleRpg.Entities;

public class Npc
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<DialogueOption> DialogueOptions { get; set; }
    public virtual List<Quest> Quests { get; set; }

    public Npc()
    {
        DialogueOptions = new List<DialogueOption>();
        Quests = new List<Quest>();
    }
}