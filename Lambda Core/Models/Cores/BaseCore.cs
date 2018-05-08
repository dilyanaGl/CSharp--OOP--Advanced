using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LambdaCore_Skeleton.Collection;
using LambdaCore_Skeleton.Contracts;
using LambdaCore_Skeleton.Enums;

namespace LambdaCore_Skeleton.Models.Cores
{
    public abstract class BaseCore : ICore
    {
        private char letter;
        private int durability;
        private LStack fragments;
        private State state;
        private int pressure;
        private int initialDurability;

        protected BaseCore(char letter, int durability)
        {
            Letter = letter;
            Durability = durability;
            this.fragments = new LStack();
            this.state = State.Normal;
            this.initialDurability = durability;
        }

        public LStack Fragments { get => this.fragments; }

        public char Letter { get => letter; private set => letter = value; }
        public void CheckPressure()
        {
            if (this.Fragments.TotalPressureAffection > 0)
            {
                this.Durability -= this.Fragments.TotalPressureAffection;
                this.state = State.Critical;
            }
            else
            {
                this.state = State.Normal;
                this.Durability = InitialDurability;
            }
        }

        public int InitialDurability { get; protected set; }


        public int Durability
        {
            get => durability;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                durability = value;
            }
        }

        public override string ToString()
        {

            return $"Core {Letter}:" + Environment.NewLine + $"####Durability: {Durability}" + Environment.NewLine +
                   $"####Status: {state.ToString().ToUpper()}";
        }
    }
}
