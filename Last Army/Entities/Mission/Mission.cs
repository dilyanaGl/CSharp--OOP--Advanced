using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Army.Entities.Mission
{
   public abstract class Mission : IMission
    {
        string name;
        private double enduranceRequired;
        private double scoreToComplete;

        public Mission(string name, double enduranceRequired, double scoreToComplete)
        {
            this.name = name;
            this.enduranceRequired = enduranceRequired;
            this.scoreToComplete = scoreToComplete;
        }

        public string Name { get => this.name; }
        public double EnduranceRequired { get => this.enduranceRequired; }
        public double ScoreToComplete { get => this.scoreToComplete; }
        public abstract double WearLevelDecrement { get; }
        public IEnumerable<IAmmunition> MissionWeapons { get; set; }
    }
}
