namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Services.Contracts;

    public class AcceptFriendCommand : ICommand
    {
        private const int DataLength = 2;
        private const string InvalidCommandMessage = "Command AcceptFriend not valid!";

        private readonly IUserService userService;

        public AcceptFriendCommand(IUserService userService)
        {
            this.userService = userService;
        }
        
        // AcceptFriend <username1> <username2>
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
                throw new ArgumentException(string.Format(AcceptFriendMessages.AnyOfTheUsersDoNotExistMessage, username));
            }

            if (!friendExists)
            {
                throw new ArgumentException(string.Format(AcceptFriendMessages.AnyOfTheUsersDoNotExistMessage, friendUsername));
            }

            var user = this.userService.ByUsername<UserFriendsDto>(username);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendUsername);

            bool isSendRequestFromFriend = friend.Friends.Any(f => f.Username == user.Username);

            if (!isSendRequestFromFriend)
            {
                throw new InvalidOperationException(string.Format(AcceptFriendMessages.NoSuchRequest, friendUsername, username));
            }

            this.userService.AcceptFriend(user.Id, friend.Id);

            string result = string.Format(AcceptFriendMessages.SuccessMessage, username, friendUsername);

            return result;
        }
    }
}