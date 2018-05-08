using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Army.Entities.Soldiers
{
   public class Ranker : Soldier
    {
        private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet",
        };

        public Ranker(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
        {
        }

        public override double OverallSkill => base.OverallSkill * 1.5;

        public override IReadOnlyList<string> WeaponsAllowed { get => this.weaponsAllowed; }

        public override void Regenerate()
        {
            this.Endurance += this.Age + 10;
        }
    }
}
