using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Last_Army.Interfaces;

namespace Last_Army.Core
{
    public class Output
    {
        private IArmy army;
        private IWareHouse warehouse;
        private StringBuilder result;

        public Output(IArmy army, IWareHouse warehouse, StringBuilder result)
        {
            this.army = army;
            this.warehouse = warehouse;
            this.result = result;
        }

        public string GiveOutput(string addedResult, int missionQueueCount, int successMissionsCount)
        {
            if (!addedResult.Equals(String.Empty))
            {
               result.AppendLine(addedResult);
            }
            result.AppendLine("Results:");
            result.AppendLine($"Successful missions - {successMissionsCount}");
            result.AppendLine($"Failed missions - {missionQueueCount}");
            result.AppendLine("Soldiers:");

            var orderedArmy = army.Soldiers.OrderByDescending(s => s.OverallSkill);
            int totalAmmunitions = 0;

            foreach (var soldier in orderedArmy)
            {
                result.AppendLine(soldier.ToString());
            }

            return result.ToString().Trim();
        }
    }
}