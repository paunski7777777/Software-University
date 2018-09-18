namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    using System;

    public class LoginCommand : ICommand
    {
        private const int DataLength = 2;
        private const string InvalidCommandMessage = "Command Login not valid!";

        private readonly ISessionService sessionService;
        private readonly IUserService userService;

        public LoginCommand(ISessionService sessionService, IUserService userService)
        {
            this.sessionService = sessionService;
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            if (args.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string username = args[0];
            string password = args[1];

            var userExist = this.userService.Exists(username);

            if (!userExist)
            {
                throw new ArgumentException(LoginMessages.UserNotFound);
            }

            var user = this.userService.ByUsername<User>(username);

            if (user.Password != password)
            {
                throw new ArgumentException(LoginMessages.PasswordDoesNotMatch);
            }

            if (this.sessionService.IsAuthenticated())
            {
                user = this.sessionService.User;

                if (user.Username == username)
                {
                    throw new ArgumentException(LoginMessages.UserHasLoggedInAlready);
                }

                throw new InvalidOperationException(LoginMessages.InvalidCredentials);
            }

            this.sessionService.Login(username, password);

            return string.Format(LoginMessages.SuccessMessage, username);
        }
    }
}