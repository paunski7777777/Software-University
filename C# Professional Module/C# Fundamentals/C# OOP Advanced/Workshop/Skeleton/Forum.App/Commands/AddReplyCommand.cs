namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFactory;
        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params string[] args)
        {
            int postId = int.Parse(args[0]);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length) + "Menu";

            IMenu menu = this.menuFactory.CreateMenu(menuName);

            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}