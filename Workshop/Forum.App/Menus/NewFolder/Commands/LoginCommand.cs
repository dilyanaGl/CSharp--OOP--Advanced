using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Menus.NewFolder.Commands
{
   public class LogInCommand : ICommand
   {
       private IUserService service;
       private IMenuFactory factory;

        public LogInCommand(IUserService service, IMenuFactory factory)
        {
            this.service = service;
            this.factory = factory;
        }

        public IMenu Execute(params string[] args)
        {
            string userName = args[0];
            string password = args[1];

            bool success = this.service.TryLogInUser(userName, password);
            if (!success)
            {
                throw new InvalidOperationException("Invaid login!");
            }

            return this.factory.CreateMenu("MainMenu");

        }
    }
}
