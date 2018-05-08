using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface ICommand
    {
        HeroManager manager { get; }

        List<String> args { get; }
        string Execute();
    }
}
