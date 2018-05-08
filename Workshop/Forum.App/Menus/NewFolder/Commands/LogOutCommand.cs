using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Menus.NewFolder.Commands
{
    public class LogOutMenuCommand : ICommand
    {
        private ISession session;
        private IMenuFactory factory;

        public LogOutMenuCommand(ISession session, IMenuFactory factory)
        {
            this.session = session;
            this.factory = factory;
        }

        public IMenu Execute(params string[] args)
        {
            this.session.Reset();
            return this.factory.CreateMenu("MainMenu");
        }
    }
}
