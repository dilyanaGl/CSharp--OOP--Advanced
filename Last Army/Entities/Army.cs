using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Last_Army.Interfaces;
using Last_Army.IO;

namespace Last_Army.Entities
{
    public class Army : IArmy
    {
        private List<ISoldier> soldiers;
        private IWareHouse warehouse;

        public Army(IWareHouse warehouse)
        {
            this.soldiers = new List<ISoldier>();
            this.warehouse = warehouse;
        }

        public IReadOnlyList<ISoldier> Soldiers { get => this.soldiers; }

        public void AddSoldier(ISoldier soldier, StringBuilder result)
        {
            if (!this.warehouse.TryEquipSoldier(soldier))
            {
                result.AppendLine(String.Format(OutputMessages.SoldierIsNotArmed, soldier.GetType().Name,
                    soldier.Name));
            }
            else
            {
                this.soldiers.Add(soldier);
            }
        }

        public void RegenerateTeam(string soldierType)
        {
            throw new NotImplementedException();
        }
    }
}
