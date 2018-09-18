namespace Forum.App.Commands
{
    using Forum.App.Contracts;
    public class CategoriesMenuCommand : NavigationCommand
    {
        public CategoriesMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        {
        }
    }
}
