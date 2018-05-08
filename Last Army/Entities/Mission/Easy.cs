using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Army.Entities.Mission
{
    public class Easy : Mission
    {
        private const int enduranceRequired = 20;
        private const string name = "Suppression of civil rebellion";

        public Easy(double scoreToComplete) : base(name, enduranceRequired, scoreToComplete)
        {
        }

        public override double WearLevelDecrement { get => 30; }
    }
}
