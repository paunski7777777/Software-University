namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class SignUpMenuCommand : NavigationCommand
    {
        public SignUpMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        {
        }
    }
}
