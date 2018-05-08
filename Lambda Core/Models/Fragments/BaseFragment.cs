using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LambdaCore_Skeleton.Contracts;

namespace LambdaCore_Skeleton.Models.Fragments
{
    using System.Runtime.Remoting.Metadata.W3cXsd2001;

    using LambdaCore_Skeleton.Enums;

    public class BaseFragment : IFragment
    {
        private string name;

        private FragmentType type;

        private int pressureAffection;

        protected BaseFragment(string name, int pressureAffection)
        {
            this.Name = name;
            this.PressureAffection = pressureAffection;
            this.PressureOnCore = pressureAffection;
        }

        public string Name { get; protected set; }

        public FragmentType Type { get; protected set; }

        public virtual int PressureAffection
        {
            get => this.pressureAffection;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                pressureAffection = value;
            }
        }

        public int PressureOnCore { get; protected set; }
    }
}
