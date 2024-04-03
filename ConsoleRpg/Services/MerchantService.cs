using ConsoleRpg.Context;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.Types;
using ConsoleRpg.Models.Npcs;
using ConsoleRpg.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using ConsoleRpg.Dao;

namespace ConsoleRpg.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly MerchantRepository _merchantRepository;

        public MerchantService(MerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public Merchant GetMerchant()
        {
            return _merchantRepository.GetFirstMerchant() ?? throw new Exception("No merchant found.");
        }

        public void VisitMerchant()
        {
            var merchant = GetMerchant();

            CustomConsole.Info($"Welcome to {merchant.Name}'s shop!");

            CustomConsole.Info("Available items:");
            foreach (var item in _merchantRepository.GetMerchantInventory(merchant))
            {
                if (item is ISellable sellableItem)
                {
                    CustomConsole.Info($"{item.Name}: {item.Description}, Cost: {sellableItem.Price} gold");
                }
            }
        }
    }

}
