using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class ViewCurrentQuestsCommand : ICommand
{
    private readonly IQuestService _questService;

    public ViewCurrentQuestsCommand(IQuestService questService)
    {
        _questService = questService;
    }

    public void Execute(string[] parameters)
    {

        _questService.ShowActiveQuests();
    }

}