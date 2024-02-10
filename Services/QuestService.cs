using ConsoleRpg.Entities;

namespace ConsoleRpg.Services;

public class QuestService
{
    private readonly RpgContext _context;

    public QuestService(RpgContext context)
    {
        _context = context;
    }

    public void AddQuest(Player player, Quest quest)
    {
        player.ActiveQuests.Add(quest);
        _context.SaveChanges();
    }

    public void CompleteQuest(Player player, Quest quest)
    {
        quest.IsCompleted = true;
        player.ActiveQuests.Remove(quest);
        player.GainExperience(quest.RewardExperience);
        player.Gold += quest.RewardGold;
        _context.SaveChanges();
    }

    public List<Quest> GetActiveQuests(Player player)
    {
        return player.ActiveQuests;
    }

    public void PickUpQuest(Player player, Quest quest)
    {
        if (quest != null)
        {
            AddQuest(player, quest);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nYou have picked up a new quest: {quest.Name}\n");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThere is no quest to pick up in this location.\n");
            Console.ResetColor();
        }
    }
}
