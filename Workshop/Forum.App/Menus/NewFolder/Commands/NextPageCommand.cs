using Forum.App.Contracts;
using System;

namespace Forum.App.Menus.NewFolder.Commands
{
    public class NextPageCommand : IPaginatedMenu, ICommand
    {
        private ISession session;

        public NextPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            IMenu currentMenu = this.session.CurrentMenu;
            if (currentMenu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage();
            }

            return currentMenu;
        }

        public void ChangePage(bool forward = true)
        {
           
        }
    }
}
