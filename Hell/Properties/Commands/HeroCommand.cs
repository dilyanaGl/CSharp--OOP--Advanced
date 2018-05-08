using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hell.Core;
using Hell.Interfaces;

namespace Hell.Commands
{
    public class HeroCommand : AbstractCommand
    {
        private List<String> list;
        private HeroManager manager;

       public HeroCommand(HeroManager manager, List<string> list) : base(manager, list)
        {
            this.list = list;
            this.manager = manager;
        }


        public override string Execute()
        {
            return manager.AddHero(list);

        }
    }
}
