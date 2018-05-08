using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hell.Commands;
using Hell.Entities.Items;
using Hell.Interfaces;


namespace Hell.Properties.Commands
{
    class RecipeCommand : AbstractCommand
    {
        public RecipeCommand(HeroManager manager, List<string> args) : base(manager, args)
        {

        }

        public override string Execute()
        {
            try
            {
                string heroName = args[1];
                IHero hero = this.manager.heroes[heroName];
                string itemName = args[0];

                int strengthBonus = int.Parse(args[2]);
                int agilityBonus = int.Parse(args[3]);
                int intelligenceBonus = int.Parse(args[4]);
                int hitPointsBonus = int.Parse(args[5]);
                int damageBonus = int.Parse(args[6]);
                List<string> neededList = args.Skip(7).ToList();
                IRecipe recipeItem = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus,
                    hitPointsBonus, damageBonus, neededList);
                hero.AddRecipe(recipeItem);

                return string.Format(Constants.RecipeCreatedMessage, itemName, heroName);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
