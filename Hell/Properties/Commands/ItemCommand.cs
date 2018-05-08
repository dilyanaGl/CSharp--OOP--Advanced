using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hell.Interfaces;

namespace Hell.Commands
{
    public class ItemCommand : AbstractCommand, ICommand
    {
      
        public ItemCommand(HeroManager manager, List<string> args) : base(manager, args)
        {

        }
        public override string Execute()
        {
            string name = this.args[1];
            if (this.manager.heroes.ContainsKey(name))
            {
                IHero hero = this.manager.heroes[name];
                return this.manager.AddItemToHero(args, hero);
            }

            return "Hero does not exist!";

        }


    }
}
