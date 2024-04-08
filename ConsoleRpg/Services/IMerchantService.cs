using ConsoleRpg.Models.Npcs;

namespace ConsoleRpg.Services;

public interface IMerchantService
{
    Merchant GetMerchant();
    void VisitMerchant();
}