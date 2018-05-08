using System;
using System.Linq;
using System.Reflection;

namespace Last_Army.Factory
{
    public class AmmunitionFactory
    {
        public AmmunitionFactory()
        {
        }

        public IAmmunition CreateAmmunition(string name)
        {
            var clazz = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(p => p.Name == name);

            if (clazz == null)
            {
                throw new ArgumentException("No such weapon exists");
            }

            var ctor = clazz.GetConstructors()[0];

            object[] parameter = new object[] {name};

            IAmmunition weapon = (IAmmunition) ctor.Invoke(parameter);
            return weapon;
        }
    }
}