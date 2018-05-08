using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Last_Army.Factory;
using Last_Army.Interfaces;

namespace Last_Army.Entities
{
    public class WareHouse : IWareHouse
    {
        private Dictionary<string, int> wareHouse;
        private AmmunitionFactory factory;

        public WareHouse()
        {
            this.wareHouse = new Dictionary<string, int>();
            this.factory = new AmmunitionFactory();
        }

        public IReadOnlyDictionary<string, int> Weapons { get => this.wareHouse; }

        public void AddAmmunition(string name, int count)
        {
            if (!this.wareHouse.ContainsKey(name))
            {
                this.wareHouse.Add(name, 0);

            }
            wareHouse[name] += count;
        }

        public void RemoveAmmunition(string name)
        {
            if (this.wareHouse.ContainsKey(name))
            {
                this.wareHouse[name]--;
            }

        }

        public void EquipArmy(IArmy army)
        {
            foreach (var soldier in army.Soldiers)
            {
                TryEquipSoldier(soldier);
            }
        }

        public bool TryEquipSoldier(ISoldier soldier)
        {
            bool isEquipped = true;
            var missingWeapons = soldier.Weapons.Where(p => p.Value == null).Select(p => p.Key).ToList();

            foreach (var weapon in missingWeapons)
            {
                if (this.Weapons.ContainsKey(weapon) && this.Weapons[weapon] > 0) 
                {
                    soldier.Weapons[weapon] = factory.CreateAmmunition(weapon);
                    this.wareHouse[weapon]--;
                }
                else
                {
                    isEquipped = false;
                }
            }

            return isEquipped;
        }
    }
}
