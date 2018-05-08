using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Army.Entities.Mission
{
   public class Hard : Mission
    {
        private const int enduranceRequired = 80;
        private const string name = "Disposal of terrorists";

        public Hard(double scoreToComplete) : base(name, enduranceRequired, scoreToComplete)
        {
        }

        public override double WearLevelDecrement { get => 70; }
    }
}
