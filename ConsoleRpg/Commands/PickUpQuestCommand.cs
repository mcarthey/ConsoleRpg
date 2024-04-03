using ConsoleRpg.Entities;
using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class PickUpQuestCommand : ICommand
{
    private readonly QuestService? _questService;
    private readonly Quest? _quest;

    public PickUpQuestCommand(QuestService questService)
    {
        _questService = questService;
    }
    
    public PickUpQuestCommand(Quest quest)
    {
        _quest = quest;
    }

    public void Execute(string[] parameters)
    {
        if (parameters.Length == 0)
        {
            throw new ArgumentException("A quest name must be provided.");
        }

        var questName = parameters[0];
        var quest = _questService.GetQuestByName(questName);
        if (quest == null)
        {
            throw new InvalidOperationException($"Quest '{questName}' not found.");
        }

        _questService.PickUpQuest(quest);
    }
}