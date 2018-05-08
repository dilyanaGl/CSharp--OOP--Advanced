using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Menus.NewFolder.Commands
{
   public class AddPostMenuCommand : ICommand
   {
       private IMenuFactory factory;

        public AddPostMenuCommand(IMenuFactory factory)
        {
            this.factory = factory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);
            IMenu menu = this.factory.CreateMenu(menuName);
            return menu;
        }
    }
}
