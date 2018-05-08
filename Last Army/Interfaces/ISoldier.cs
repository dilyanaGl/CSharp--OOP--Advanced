using System.Collections.Generic;

public interface ISoldier
{
    string Name { get; }

    int Age { get; }

    double Experience { get; }

    double Endurance { get; set; }

    double OverallSkill { get; }

    IDictionary<string, IAmmunition> Weapons { get; set; }

    IReadOnlyList<string> WeaponsAllowed { get; }

    void Regenerate();

    bool ReadyForMission(IMission mission);

    void CompleteMission(IMission mission);
}