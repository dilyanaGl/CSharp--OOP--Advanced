using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hell.Entities.Items;

namespace Hell.Interfaces
{
    public interface IRecipe : IItem
    {
        string Name { get; }
        IList<string> RequiredItems { get; }
    }
}
