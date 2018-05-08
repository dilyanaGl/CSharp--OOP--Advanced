using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Commands
{
    class InspectCommand : AbstractCommand
    {
        public InspectCommand(HeroManager manager, List<string> args) : base(manager, args)
        {
        }

        public override string Execute()
        {
            return this.manager.Inspect(args);
        }
    }
}
