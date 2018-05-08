using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Entities.Heroes
{
   public class Assassin : AbstractHero
    {
        protected Assassin(string name) : base(name, 25, 100, 15, 150, 300)
        {
        }
    }
}
