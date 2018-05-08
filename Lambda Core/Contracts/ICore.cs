using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LambdaCore_Skeleton.Collection;

namespace LambdaCore_Skeleton.Contracts
{
   public interface ICore
    {
        int Durability { get; }
        LStack Fragments { get; }
        char Letter { get; }
        void CheckPressure();
    }
}
