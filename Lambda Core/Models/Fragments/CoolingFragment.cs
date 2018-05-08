using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Models.Fragments
{
    class CoolingFragment : BaseFragment
    {
        private const int multiplication = 3;
        private int pressureAffetion;
        
        public CoolingFragment(string name, int pressureAffection)
            : base(name, pressureAffection )
        {
            this.PressureOnCore = pressureAffection;
            this.pressureAffetion *= multiplication;
        }

        public override int PressureAffection
        {
            get => this.pressureAffetion * -1;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value must be positive");
                }

                pressureAffetion = value;
            }
        }
    }
}
