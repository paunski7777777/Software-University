namespace PhotoShare.Client.Core.Commands
{
    using System;

    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Services.Contracts;

    public class LogoutCommand : ICommand
    {
        private readonly ISessionService sessionService;
        private readonly IUserService userService;

        public LogoutCommand(ISessionService sessionService, IUserService userService)
        {
            this.sessionService = sessionService;
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            if (!this.sessionService.IsAuthenticated())
            {
                throw new InvalidOperationException(LogoutMessages.ThereIsNoUserLoggedIn);
            }

            var user = this.sessionService.User;

            this.sessionService.Loguot();

            return string.Format(LogoutMessages.SuccessMessage);
        }
    }
}