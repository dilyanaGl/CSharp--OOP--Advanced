using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Army.Entities.Mission
{
    public class Medium : Mission
    {
        private const int enduranceRequired = 50;
        private const string name = "Capturing dangerous criminals";

        public Medium(double scoreToComplete) : base(name, enduranceRequired, scoreToComplete)
        {
        }

        public override double WearLevelDecrement { get => 50; }
    }
}
