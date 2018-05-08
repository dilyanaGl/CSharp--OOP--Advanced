using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hell.Interfaces;

namespace Hell.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        public HeroManager manager { get; private set; }
        public List<string> args { get; private set; }

        

        protected AbstractCommand(HeroManager manager, List<string> args)
        {
            this.manager = manager;
            this.args = args;
        }

        public abstract string Execute();

    }
}
