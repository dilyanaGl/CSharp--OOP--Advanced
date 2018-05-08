using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Models.Fragments
{
    using LambdaCore_Skeleton.Enums;

    class NuclearFragment : BaseFragment
    {
        public NuclearFragment(string name, int pressureAffection)
            : base(name, pressureAffection)
        {
            this.PressureOnCore = pressureAffection;
            this.PressureAffection *= 2;
        }
    }
}
