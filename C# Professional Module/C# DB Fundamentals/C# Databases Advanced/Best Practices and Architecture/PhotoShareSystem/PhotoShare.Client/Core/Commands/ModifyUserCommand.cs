namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Services.Contracts;

    public class ModifyUserCommand : ICommand
    {
        private const int DataLength = 3;
        private const string InvalidCommandMessage = "Command ModifyUser not valid!";

        public const string PasswordString = "Password";
        public const string BornTownString = "BornTown";
        public const string CurrentTownString = "CurrentTown";
        public const string ErrorMessage = "Property [{0}] not supported!";

        private readonly IUserService userService;
        private readonly ITownService townService;

        public ModifyUserCommand(IUserService userService, ITownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            if (data.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string username = data[0];
            string property = data[1];
            string value = data[2];

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException(string.Format(ModifyUserMessages.UserDoesNotExistMessage, username));
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            if (property == PasswordString)
            {
                SetPassword(userId, value);
            }
            else if (property == BornTownString)
            {
                SetBornTown(userId, value);
            }
            else if (property == CurrentTownString)
            {
                SetCurrentTown(userId, value);
            }
            else
            {
                throw new ArgumentException(string.Format(ErrorMessage, property));
            }

            return string.Format(ModifyUserMessages.SuccessMessage, username, property, value);
        }

        private void SetCurrentTown(int userId, string townName)
        {
            var townExists = this.townService.Exists(townName);

            if (!townExists)
            {
                string exceptionMessage = string.Format(ModifyUserMessages.ValueNotValidMessage, townName, Environment.NewLine, string.Format(ModifyUserMessages.TownNotFoundMessage, townName));
                throw new ArgumentException(exceptionMessage);
            }

            var townId = this.townService.ByName<TownDto>(townName).Id;

            this.userService.SetCurrentTown(userId, townId);
        }

        private void SetBornTown(int userId, string townName)
        {
            var townExists = this.townService.Exists(townName);

            if (!townExists)
            {
                string exceptionMessage = string.Format(ModifyUserMessages.ValueNotValidMessage, townName, Environment.NewLine, string.Format(ModifyUserMessages.TownNotFoundMessage, townName));
                throw new ArgumentException(exceptionMessage);
            }

            var townId = this.townService.ByName<TownDto>(townName).Id;

            this.userService.SetBornTown(userId, townId);
        }

        private void SetPassword(int userId, string password)
        {
            var isLower = password.Any(x => char.IsLower(x));
            var isDigit = password.Any(x => char.IsDigit(x));

            if (!isLower || !isDigit)
            {
                throw new ArgumentException(string.Format(ModifyUserMessages.ValueNotValidMessage, password, Environment.NewLine, ModifyUserMessages.InvalidPasswordMessage));
            }

            this.userService.ChangePassword(userId, password);
        }
    }
}