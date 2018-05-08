using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;


namespace Forum.App.Menus.NewFolder.Commands
{
    class LogInMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;
        private IUserService service;

        public LogInMenuCommand(IMenuFactory menuFactory, IUserService service)
        {
            this.menuFactory = menuFactory;
            this.service = service;
        }
        
      
        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;

            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = (IMenu)this.menuFactory.CreateMenu(menuName);
            return menu;
        }
    }
}
