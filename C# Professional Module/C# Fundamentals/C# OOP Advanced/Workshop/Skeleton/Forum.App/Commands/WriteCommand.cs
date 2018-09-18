namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class WriteCommand : ICommand
    {
        private ISession session;
        public WriteCommand(ISession session)
        {
            this.session = session;
        }
        public IMenu Execute(params string[] args)
        {
            IMenu currentMenu = this.session.CurrentMenu;

            if (currentMenu is ITextAreaMenu textAreaMenu)
            {
                textAreaMenu.TextArea.Write();
            }

            return currentMenu;
        }
    }
}
