namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Services.Contracts;

    public class RegisterUserCommand : ICommand
    {
        private const int DataLength = 4;
        private const string InvalidCommandMessage = "Command RegisterUser not valid!";

        private readonly IUserService userService;

        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            if (data.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string username = data[0];
            string password = data[1];
            string reapeatPassword = data[2];
            string email = data[3];

            var registerUserDto = new RegisterUserDto
            {
                Username = username,
                Password = password,
                Email = email
            };
            
            var userExist = this.userService.Exists(username);

            if (userExist)
            {
                throw new InvalidOperationException(string.Format(RegisterUserMessages.UserIsTakenMessage, username));
            }

            if (password != reapeatPassword)
            {
                throw new ArgumentException(RegisterUserMessages.PasswordDontMatchMessage); 
            }

            this.userService.Register(username, password, email);

            string result = string.Format(RegisterUserMessages.SuccessMessage, username);

            return result;
        }
    }
}
