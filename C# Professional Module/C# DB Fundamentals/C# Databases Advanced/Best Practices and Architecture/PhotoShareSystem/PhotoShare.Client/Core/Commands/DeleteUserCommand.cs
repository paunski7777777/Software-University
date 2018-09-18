namespace PhotoShare.Client.Core.Commands
{
    using System;
    
    using Contracts;
    using PhotoShare.Client.Utilities.OutputMessages;
    using Services.Contracts;

    public class DeleteUserCommand : ICommand
    {
        private const int DataLength = 1;
        private const string InvalidCommandMessage = "Command DeleteUser not valid!";

        private readonly IUserService userService;

        public DeleteUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            if (data.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string username = data[0];

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException(DeleteUserMessages.UserDoesNotExistMessage);
            }

            //var userIsDeleted = this.userService.ByUsername<UserDto>(username).IsDeleted;

            //if (userIsDeleted is true)
            //{
            //    throw new InvalidOperationException(string.Format(DeleteUserMessages.UserIsAlreadyDeletedMessage, username));
            //}

            this.userService.Delete(username);

            string result = string.Format(DeleteUserMessages.SuccessMessage, username);

            return result;
        }
    }
}