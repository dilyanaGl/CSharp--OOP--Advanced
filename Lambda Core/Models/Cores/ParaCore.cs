using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LambdaCore_Skeleton.Contracts;

namespace LambdaCore_Skeleton.Models.Cores
{

    public class ParaCore : BaseCore
    {
        private const int division = 3;
        private int durability;
        
        public ParaCore(char letter, int durability) : base(letter, durability)
        {
            this.Durability /= 3;
            this.InitialDurability = this.Durability;
        }
    }
}
