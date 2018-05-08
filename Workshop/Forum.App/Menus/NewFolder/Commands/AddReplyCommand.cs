using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Menus.NewFolder.Commands
{
    public class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFacotry)
        {
            this.menuFactory = menuFacotry;
        }

        public IMenu Execute(params string[] args)
        {
            var commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length) + "Menu";

            IMenu menu = this.menuFactory.CreateMenu(menuName);

            if (menu is IIdHoldingMenu idMenu)
            {
                idMenu.SetId(int.Parse(args[0]));
            }

            return menu;


        }
    }
}
