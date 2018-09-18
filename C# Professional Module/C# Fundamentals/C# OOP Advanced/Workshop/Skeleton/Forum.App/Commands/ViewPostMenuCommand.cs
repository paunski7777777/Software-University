namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class ViewPostMenuCommand : ICommand
    {
        private ISession session;
        private IMenuFactory menuFactory;
        public ViewPostMenuCommand(ISession session, IMenuFactory menuFactory)
        {
            this.session = session;
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params string[] args)
        {
            int postId = int.Parse(args[0]);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu currentMenu = this.menuFactory.CreateMenu(menuName);

            if (currentMenu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(postId);
            }

            return currentMenu;
        }
    }
}
