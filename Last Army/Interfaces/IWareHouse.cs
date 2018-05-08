using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Army.Interfaces
{
    public interface IWareHouse
    {
        void EquipArmy(IArmy army);

        void AddAmmunition(string name, int count);

        void RemoveAmmunition(string name);

        bool TryEquipSoldier(ISoldier soldier);

        IReadOnlyDictionary<string, int> Weapons { get; }
    }
}
