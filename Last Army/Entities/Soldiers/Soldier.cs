using System;
using System.Collections.Generic;
using System.Linq;
using Last_Army.IO;

public abstract class Soldier : ISoldier
{
    private double endurance;
    private string name;
    private double experience;
    private int age;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.endurance = endurance;
        this.name = name;
        this.experience = experience;
        this.age = age;
        this.Weapons = InitializeWeapons();
    }

    private IDictionary<string, IAmmunition> InitializeWeapons()
    {
        var weapons = new Dictionary<string, IAmmunition>();
        for (int i = 0; i < this.WeaponsAllowed.Count; i++)
        {
            weapons.Add(this.WeaponsAllowed[i], null);
        }

        return weapons;
    }

    public string Name { get => this.name; }
    public int Age { get => this.age; }
    public double Experience { get => this.experience; }
    public double Endurance
    {
        get => this.endurance;
        set
        {
            if (value > 100)
            {
                value = 100;
            }

            this.endurance = value;
        }
    }
    public virtual double OverallSkill { get => this.age + this.experience; }

    public IDictionary<string, IAmmunition> Weapons { get; set; }

    public abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public abstract void Regenerate();

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public void CompleteMission(IMission mission)
    {

        this.Endurance -= mission.EnduranceRequired;
        this.experience += mission.EnduranceRequired;
        AmmunitionRevision(mission.WearLevelDecrement);
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();

        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public void GetBonus()
    {
        throw new System.NotImplementedException();
    }
}