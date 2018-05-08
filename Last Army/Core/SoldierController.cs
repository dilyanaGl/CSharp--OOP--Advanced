using System.Collections.Generic;
using System.Linq;
using Last_Army.Interfaces;

namespace Last_Army.Core
{
    public class SoldierController
    {
        private IArmy army;
        private IWareHouse wareHouse;

        public SoldierController(IArmy army, IWareHouse wareHouse)
        {
            this.army = army;
            this.wareHouse = wareHouse;
        }

        public void SoldierChangesAfterSuccessfulMission(IMission mission, string rankerType)
        {
            var rankTypeSoldiers = this.army.Soldiers.Where(p => p.GetType().Name == rankerType).ToList();

            foreach (var soldier in rankTypeSoldiers)
            {
                soldier.Endurance -= mission.EnduranceRequired;
            }
        }

        public void TeamGetBonus(Dictionary<string, List<Soldier>> army, string rankerType)
        {
            foreach (var soldiers in army[rankerType])
            {
                soldiers.GetBonus();
            }
        }

        public void TeamRegenerate(string rankerType)
        {
            if (this.army.Soldiers.Count > 0)
            {
                var regenerators = this.army.Soldiers.Where(p => p.GetType().Name == rankerType).ToList();
                if (regenerators.Count > 0)
                {
                    regenerators.ForEach(r => r.Regenerate());
                }
            }
        }
    }
}