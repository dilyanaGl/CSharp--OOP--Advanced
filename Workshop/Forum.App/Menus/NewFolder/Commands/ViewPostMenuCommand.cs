using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Menus.NewFolder.Commands
{
    public class ViewPostMenuCommand : ICommand
    {
        private IMenuFactory factory;

        public ViewPostMenuCommand(IMenuFactory factory)
        {
            this.factory = factory;

        }

        public IMenu Execute(params string[] args)
        {

            int categoryId = int.Parse(args[0]);

            string commandName = this.GetType().Name;

            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = (IMenu)this.factory.CreateMenu(menuName);
            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                int id = int.Parse(args[0]);
                idHoldingMenu.SetId(id);
            }

           

            return menu;
        }
    }
}
