using ConsoleRpg.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Npcs.Types
{
    public class InformativeNpc: Npc, IInformative
    {
        public void ProvideInformation()
        {
            throw new NotImplementedException();
        }
    }

    public interface IInformative
    {
        void ProvideInformation();
    }
}
