using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Last_Army.Factory
{
    public class MissionFactory : IMissionFactory
    {
       public IMission CreateMission(string difficultyLevel, double neededPoints)
       {
           var clazz = Assembly.GetExecutingAssembly()
               .GetTypes()
               .FirstOrDefault(p => p.Name == difficultyLevel);

           if (clazz == null)
           {
               throw new ArgumentException("No such mission name exists");
           }

           var ctor = clazz.GetConstructors()[0];
           object[] parameters = new object[] {neededPoints};

           IMission mission = (IMission) ctor.Invoke(parameters);

           return mission;
       }
    }
}
