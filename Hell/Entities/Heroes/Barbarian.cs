using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Entities.Heroes
{
    public class Barbarian : AbstractHero
    {
        protected Barbarian(string name) : base(name, 90, 25, 10, 350, 150)
        {
        }
    }
}
