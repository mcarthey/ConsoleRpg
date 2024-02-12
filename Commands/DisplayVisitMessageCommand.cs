using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class DisplayVisitMessageCommand : ICommand
{
    private readonly MerchantService _merchantService;

    public DisplayVisitMessageCommand(MerchantService merchantService)
    {
        _merchantService = merchantService;
    }

    public void Execute(string[] parameters)
    {
        _merchantService.DisplayVisitMessage();
    }
}