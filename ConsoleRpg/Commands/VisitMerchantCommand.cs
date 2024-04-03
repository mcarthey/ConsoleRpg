using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class VisitMerchantCommand : ICommand
{
    private readonly IMerchantService _merchantService;

    public VisitMerchantCommand(IMerchantService merchantService)
    {
        _merchantService = merchantService;
    }

    public void Execute(string[] parameters)
    {
        _merchantService.VisitMerchant();
    }
}