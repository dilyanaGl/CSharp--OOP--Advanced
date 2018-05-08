using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface IInventory
    {
        void AddRecipeItem(IRecipe recipe);
       
        void AddCommonItem(IItem item);

      long TotalStrengthBonus
        {
            get ; 
        }

         long TotalAgilityBonus
        {
            get; 
        }

        long TotalIntelligenceBonus
        {
            get; 
        }

         long TotalHitPointsBonus
        {
            get ; 
        }

        long TotalDamageBonus
        {
            get; 
        }
    }
}
