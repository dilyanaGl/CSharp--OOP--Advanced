using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Hell.Entities.Items;
using Hell.Interfaces;

public class AbstractHero : IHero, IComparable<AbstractHero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;
    private string name;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.Strength = strength;
        this.Agility = agility;
        this.Intelligence = intelligence;
        this.HitPoints = hitPoints;
        this.Damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; private set; }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    public List<IItem> Items
    {
        get
        {
            Type clazz = typeof(HeroInventory);
            var field = clazz
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(ItemAttribute), false).Count() == 1);

            object result = field.GetValue(this.inventory);
            var dict = (IDictionary<string, IItem>)result;
            List<IItem> list = dict.Select(p => p.Value).ToList();
            return list;
        }
    }

    public long Strength { get => strength + this.inventory.TotalStrengthBonus; private set => strength = value; }
    public long Agility { get => agility + this.inventory.TotalAgilityBonus; private set => agility = value; }
    public long Intelligence { get => intelligence + this.inventory.TotalIntelligenceBonus; private set => intelligence = value; }
    public long HitPoints { get => hitPoints + this.inventory.TotalHitPointsBonus; private set => hitPoints = value; }
    public long Damage { get => damage + this.inventory.TotalDamageBonus; private set => damage = value; }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public void AddCommonItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }

        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public string Inspect()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Hero: { Name}, Class: { this.GetType().Name}");
        sb.AppendLine($"HitPoints: { HitPoints}, Damage: { Damage}");
        sb.AppendLine($"Strength: { Strength}");
        sb.AppendLine($"Agility: {Agility}");
        sb.AppendLine($"Intelligence: {Intelligence}");

        if (this.Items.Count == 0)
        {
            sb.AppendLine("Items: None");
        }
        else
        {
            sb.AppendLine("Items: ");
            this.Items.ForEach(p => sb.AppendLine(p.ToString()));
        }

        return sb.ToString().Trim();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name}: {Name}");
        sb.AppendLine($"###HitPoints: {this.HitPoints}");
        sb.AppendLine($"###Damage: {this.Damage}");
        sb.AppendLine($"###Strength: {Strength}");
        sb.AppendLine($"###Agility: {Agility}");
        sb.AppendLine($"###Intelligence: {Intelligence}");
        if (this.Items.Count == 0)
        {
            sb.AppendLine("###Items: None");
        }
        else
        {
            sb.AppendLine(String.Format("###Items: {0}",
                string.Join(", ", this.Items.Select(p => p.Name))));
        }

        return sb.ToString();
    }
}