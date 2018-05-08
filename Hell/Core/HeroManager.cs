using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Hell.Commands;
using Hell.Core;
using Hell.Entities.Items;
using Hell.Interfaces;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(List<String> arguments)
    {
        string result = null;
        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(p => p.Name.Equals(heroType, StringComparison.InvariantCultureIgnoreCase));
            var constructors = clazz.GetConstructors(BindingFlags.Public | BindingFlags.Static |
                                                     BindingFlags.NonPublic | BindingFlags.Instance);
         
            IHero hero = (AbstractHero)constructors[0].Invoke(new object[] {heroName});
            this.heroes.Add(heroName, hero);
            result = string.Format(Constants.HeroCreateMessage, heroType, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(List<String> arguments, IHero hero)
    {
        string result = null;
        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);
        heroes[heroName].AddCommonItem(newItem);
        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string CreateGame()
    {
        StringBuilder result = new StringBuilder();

        foreach (var hero in heroes)
        {
            result.AppendLine(hero.Key);
        }

        return result.ToString();
    }

    public string Inspect(List<String> arguments)
    {
        string heroName = arguments[0];
        var hero = this.heroes[heroName];

        return hero.Inspect();
    }

    public static void GenerateResult()
    {
        const string PropName = "_connectionString";

        var type = typeof(HeroCommand);

        FieldInfo fieldInfo = null;
        PropertyInfo propertyInfo = null;
        while (fieldInfo == null && propertyInfo == null && type != null)
        {
            fieldInfo = type.GetField(PropName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo == null)
            {
                propertyInfo = type.GetProperty(PropName,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            }

            type = type.BaseType;
        }
    }
}