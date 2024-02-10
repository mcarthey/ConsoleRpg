using ConsoleRpg.Entities;
using ConsoleRpg.Services;

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
        player.ActiveQuests.Add(quest);
        _context.SaveChanges();
    }

    public void CompleteQuest(Quest quest)
    {
        var player = _playerService.GetPlayer();
        if (quest.KillCount > 0 && quest.KillCountProgress < quest.KillCount)
        {
            Console.WriteLine("You have not killed enough enemies to complete this quest.");
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
        return player.ActiveQuests;
    }

    public void PickUpQuest(Quest quest)
    {
        var player = _playerService.GetPlayer();
        if (quest != null)
        {
            AddQuest(quest);
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
