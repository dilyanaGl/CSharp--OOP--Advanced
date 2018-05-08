using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hell.Interfaces;

namespace Hell.Entities.Items
{
   public class RecipeItem : Item, IRecipe
    {
        private IList<string> requiredItems;
    
        public RecipeItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, IList<string> requiredItems) : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {
          this.RequiredItems = requiredItems;
        }

        public IList<string> RequiredItems
        {
            get { return requiredItems; }
            private set { requiredItems = value; }
        }
    }
}
