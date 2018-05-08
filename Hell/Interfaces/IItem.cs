using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface IItem            
    {
        string Name { get; }
        long StrengthBonus { get; }
        long AgilityBonus { get; } 
        long IntelligenceBonus { get; }
        long HitPointsBonus { get; }
        long DamageBonus { get; }
    }
}
