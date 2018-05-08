﻿using System.Collections.Generic;
using System.Text;

namespace Last_Army
{
    public class SpecialForce : Soldier
    {
        private const double OverallSkillMiltiplier = 3.5;
        private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

        public SpecialForce(string name, int age, double experience, double endurance)
            : base(name, age, experience, endurance)
        {
        }

        public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

        public override IReadOnlyList<string> WeaponsAllowed { get => this.weaponsAllowed; }

        public override void Regenerate()
        {
            this.Endurance += this.Age + 30;
        }
    }
}