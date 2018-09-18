namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class AddPostMenuCommand : NavigationCommand
    {
        public AddPostMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        {
        }
    }
}
