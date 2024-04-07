using ConsoleRpg.Entities;
using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class PickUpQuestCommand : ICommand
{
    private readonly IQuestService? _questService;
    private readonly Quest? _quest;

    public PickUpQuestCommand(IQuestService questService)
    {
        _questService = questService;
    }
    
    public PickUpQuestCommand(Quest quest)
    {
        _quest = quest;
    }

    public void Execute(string[] parameters)
    {
        // Check if parameters are provided
        if (parameters.Length == 0 || string.IsNullOrEmpty(parameters[0]))
        {
            throw new ArgumentException("A quest name must be provided.");
        }

        var questName = parameters[0];

        // Check if quest exists
        var quest = _questService.GetQuestByName(questName);
        if (quest == null)
        {
            throw new InvalidOperationException($"Quest '{questName}' not found.");
        }

        // Pick up the quest
        _questService.PickUpQuest(quest);
    }
}