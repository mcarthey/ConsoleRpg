using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Services;

public class QuestService : IQuestService
{
    private readonly RpgContext _context;
    private readonly IPlayerService _playerService;

    public QuestService(RpgContext context, IPlayerService playerService)
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

    public void ShowActiveQuests()
    {
        var player = _playerService.GetPlayer();
        var activeQuests = _context.Quests.Where(q => q.Players.Any(p => p.Id == player.Id) && !q.IsCompleted).ToList();


        if (activeQuests.Count == 0)
        {
            CustomConsole.Info("You have no active quests.");
        }
        else
        {
            CustomConsole.Notice("Your active quests:");
            foreach (var quest in activeQuests)
            {
                CustomConsole.Info($"{quest.Name}: {quest.Description}");
                quest.DisplayProgress();
            }
        }
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
        quest.Players.Remove(player); // Remove the player from the quest's Players list
        _playerService.GainExperience(quest.RewardExperience);
        _playerService.AddGold(quest.RewardGold);
        _context.SaveChanges();
    }

    public List<Quest> GetActiveQuests()
    {
        var player = _playerService.GetPlayer();
        return _context.Quests.Where(q => q.Players.Any(p => p.Id == player.Id) && !q.IsCompleted).ToList();
    }

    public Quest? GetQuestByName(string questName)
    {
        return _context.Quests.FirstOrDefault(q => q.Name == questName);
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