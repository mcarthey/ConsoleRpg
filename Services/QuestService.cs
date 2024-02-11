using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using Spectre.Console;

namespace ConsoleRpg.Services;

public class QuestService
{
    private readonly RpgContext _context;
    private readonly PlayerService _playerService;

    public QuestService(RpgContext context, PlayerService playerService)
    {
        _context = context;
        _playerService = playerService;
    }

    public void AddQuest(Quest quest)
    {
        var player = _playerService.GetPlayer();
        quest.Players.Add(player);
        _context.SaveChanges();
    }

    public void CompleteQuest(Quest quest)
    {
        var player = _playerService.GetPlayer();
        if (quest.KillCount > 0 && quest.KillCountProgress < quest.KillCount)
        {
            CustomConsole.Info("You have not killed enough enemies to complete this quest.");
            return;
        }

        quest.IsCompleted = true;
        player.ActiveQuests.Remove(quest);
        player.GainExperience(quest.RewardExperience);
        player.Gold += quest.RewardGold;
        _context.SaveChanges();
    }

    public List<Quest> GetActiveQuests()
    {
        var player = _playerService.GetPlayer();
        return _context.Quests.Where(q => q.Players.Any(p => p.Id == player.Id) && !q.IsCompleted).ToList();
    }

    public void PickUpQuest(Quest quest)
    {
        var player = _playerService.GetPlayer();
        if (quest != null)
        {
            AddQuest(quest);
            CustomConsole.Notice($"\nYou have picked up a new quest: {quest.Name}\n");
        }
        else
        {
            CustomConsole.Notice("\nThere is no quest to pick up in this location.\n");
        }
    }
}