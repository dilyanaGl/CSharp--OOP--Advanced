using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Last_Army.Core
{
    public class SoldiersFactory
    {
        public SoldiersFactory()
        {
        }

        public ISoldier CreateSoldier(string[] data)
        {
            string type = data[0];
            string name = data[1];
            int age = int.Parse(data[2]);
            double experience = int.Parse(data[3]);
            double endurance = double.Parse(data[4]);

            var parameters = new object[] { name, age, experience, endurance };
            var clazz = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(p => p.Name == type);
            var ctor = clazz.GetConstructors()[0];

            ISoldier soldier = (ISoldier)ctor.Invoke(parameters);
            return soldier;
        }
    }
}