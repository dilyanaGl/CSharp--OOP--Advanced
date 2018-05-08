using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            var clazz = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(p => p.Name == menuName);

            if (clazz == null)
            {
                throw new ArgumentException("Menu not found!");
            }

            else if (!typeof(IMenu).IsAssignableFrom(clazz))
            {
                throw new InvalidOperationException($"{clazz} is not a menu!");
            }
            else
            {

                ParameterInfo[] ctorParams = clazz.GetConstructors().First().GetParameters();
                var newParams = new object[ctorParams.Length];
                for (int i = 0; i < newParams.Length; i++)
                {
                    newParams[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
                }

                IMenu menu = (IMenu)Activator.CreateInstance(clazz, newParams);

                return menu;

            }
        }
    }
}
