namespace Forum.App.Commands
{
    using Forum.App.Contracts;
    using System;

    public class LogInCommand : ICommand
    {
        private const string ErrorMessage = "Invalid username or password!";

        private IUserService userService;
        private IMenuFactory menuFactory;
        public LogInCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];

            bool validUsername = !string.IsNullOrEmpty(username) && username.Length >= 4;
            bool validPassword = !string.IsNullOrEmpty(password) && password.Length >= 4;

            if (!validUsername || !validPassword)
            {
                throw new ArgumentException(ErrorMessage);
            }

            bool userLoggedIn = this.userService.TryLogInUser(username, password);

            if (!userLoggedIn)
            {
                throw new InvalidOperationException(ErrorMessage);
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
