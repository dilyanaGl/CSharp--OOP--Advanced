using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Entities.Heroes
{
    public class Wizard : AbstractHero
    {
        protected Wizard(string name) : base(name, 25, 25, 100, 100, 250)
        {
        }
    }
}
