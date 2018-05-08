using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hell.Interfaces;

namespace Hell.Entities.Items
{
    public abstract class Item : IItem
    {
        private string name;
        private long strengthBonus;
        private long agilityBonus;
        private long intelligenceBonus;
        private long hitPointsBonus;
        private long damageBonus;

        public Item(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus,
            long damageBonus)
        {
            Name = name;
            StrengthBonus = strengthBonus;
            AgilityBonus = agilityBonus;
            IntelligenceBonus = intelligenceBonus;
            HitPointsBonus = hitPointsBonus;
            DamageBonus = damageBonus;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public long StrengthBonus
        {
            get => strengthBonus;
            private set => strengthBonus = value;
        }

        public long AgilityBonus
        {
            get => agilityBonus;
            private set => agilityBonus = value;
        }

        public long IntelligenceBonus
        {
            get => intelligenceBonus;
            private set => intelligenceBonus = value;
        }

        public long HitPointsBonus
        {
            get => hitPointsBonus;
            private set => hitPointsBonus = value;
        }

        public long DamageBonus
        {
            get => damageBonus;
            private set => damageBonus = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"###Item: {Name}");
            sb.AppendLine($"###+{strengthBonus} Strength");
            sb.AppendLine($"###+{agilityBonus} Agility");
            sb.AppendLine($"###+{intelligenceBonus} Intelligence");
            sb.AppendLine($"###+{hitPointsBonus} HitPoints");
            sb.AppendLine($"###+{damageBonus} Damage");

            return sb.ToString().Trim();
        }
    }
}