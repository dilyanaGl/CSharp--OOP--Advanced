using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Menus.NewFolder.Commands
{
    public class PreviousPageCommand : ICommand, IPaginatedMenu
    {
        
        private ISession session;

        public PreviousPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            IMenu currentMenu = this.session.CurrentMenu;
            if (currentMenu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage(false);
            }

            return currentMenu;
        }

        public void ChangePage(bool forward = false)
        {
            throw new NotImplementedException();
        }
    }
}
