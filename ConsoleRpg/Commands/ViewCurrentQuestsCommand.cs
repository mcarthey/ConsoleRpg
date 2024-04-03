using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class ViewCurrentQuestsCommand : ICommand
{
    private readonly QuestService _questService;

    public ViewCurrentQuestsCommand(QuestService questService)
    {
        _questService = questService;
    }

    public void Execute(string[] parameters)
    {

        _questService.ShowActiveQuests();
    }

}