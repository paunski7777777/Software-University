using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class LogInMenuCommand : NavigationCommand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
