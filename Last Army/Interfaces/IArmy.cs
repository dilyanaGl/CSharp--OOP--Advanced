using System.Collections.Generic;
using System.Text;

public interface IArmy
{
    IReadOnlyList<ISoldier> Soldiers { get; }

    void AddSoldier(ISoldier soldier, StringBuilder result);

    void RegenerateTeam(string soldierType);
}