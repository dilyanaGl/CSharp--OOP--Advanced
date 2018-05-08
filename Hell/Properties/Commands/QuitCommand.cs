using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hell.Commands;
using Hell.Interfaces;

public class QuitCommand : AbstractCommand
{
    
    public QuitCommand(HeroManager manager, List<string> args) : base(manager, args)
    {
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        int index = 1;
        var heroesValue = this.manager.heroes.Select(p => p.Value).OrderByDescending(p => p.PrimaryStats).ThenByDescending(p => p.SecondaryStats).ToList();
        heroesValue.ForEach(p => sb.Append(String.Format("{0}. {1}", index++, p.ToString())));
        return sb.ToString().Trim();
    }
}