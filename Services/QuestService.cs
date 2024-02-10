using ConsoleRpg.Entities;

namespace ConsoleRpg.Services;

public class QuestService
{
    private RpgContext _context;

    public QuestService(RpgContext context)
    {
        _context = context;
    }

    public List<Quest> GetActiveQuests(Player player)
    {
        return player.ActiveQuests;
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
}