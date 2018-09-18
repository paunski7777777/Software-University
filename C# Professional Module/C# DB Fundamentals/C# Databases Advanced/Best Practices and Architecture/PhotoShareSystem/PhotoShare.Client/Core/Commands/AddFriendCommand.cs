namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Services.Contracts;

    public class AddFriendCommand : ICommand
    {
        private const int DataLength = 2;
        private const string InvalidCommandMessage = "Command AddFriend not valid!";

        private readonly IUserService userService;

        public AddFriendCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            if (data.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string username = data[0];
            string friendUsername = data[1];

            var userExists = this.userService.Exists(username);
            var friendExists = this.userService.Exists(friendUsername);

            if (!userExists)
            {
                throw new ArgumentException(string.Format(AddFriendMessages.AnyOfTheUsersDoNotExistMessage, username));
            }

            if (!friendExists)
            {
                throw new ArgumentException(string.Format(AddFriendMessages.AnyOfTheUsersDoNotExistMessage, friendUsername));
            }

            var user = this.userService.ByUsername<UserFriendsDto>(username);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendUsername);

            bool isRequestSentFromUser = user.Friends.Any(u => u.Username == friend.Username);
            bool isRequestSentFromFriend = friend.Friends.Any(f => f.Username == user.Username);

            if (isRequestSentFromUser && isRequestSentFromFriend)
            {
                throw new InvalidOperationException(string.Format(AddFriendMessages.TheyAreAlreadyFriendsMessage, friend.Username, user.Username));
            }
            else if (isRequestSentFromUser && !isRequestSentFromFriend)
            {
                throw new InvalidOperationException(AddFriendMessages.RequestIsAlreadySentMessage);
            }
            else if (!isRequestSentFromUser && isRequestSentFromFriend)
            {
                throw new InvalidOperationException(AddFriendMessages.RequestIsAlreadySentMessage);
            }

            this.userService.AddFriend(user.Id, friend.Id);

            string result = string.Format(AddFriendMessages.SuccessMessage, friend.Username, user.Username);

            return result;
        }
    }
}