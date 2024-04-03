using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class VisitMerchantCommand : ICommand
{
    private readonly MerchantService _merchantService;

    public VisitMerchantCommand(MerchantService merchantService)
    {
        _merchantService = merchantService;
    }

    public void Execute(string[] parameters)
    {
        _merchantService.VisitMerchant();
    }
}