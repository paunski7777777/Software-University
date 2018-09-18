namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Services.Contracts;

    using System;
    using System.Linq;
    using System.Text;

    public class ListFriendsCommand : ICommand
    {
        private const int DataLength = 1;
        private const string InvalidCommandMessage = "Command ListFriends not valid!";

        private const string FriendsMessage = "Friends:";

        private readonly IUserService userService;

        public ListFriendsCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            if (args.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string username = args[0];

            var friendsList = new StringBuilder();

            var userExist = this.userService.Exists(username);

            if (!userExist)
            {
                throw new ArgumentException(string.Format(ListFriendsMessages.UserNotFoundMessage, username));
            }

            var user = this.userService.ByUsername<UserFriendsDto>(username);

            if (!user.Friends.Any())
            {
                return ListFriendsMessages.NoFriendsMessage;
            }
            else
            {
                friendsList.AppendLine(FriendsMessage);

                foreach (var friend in user.Friends)
                {
                    friendsList.AppendLine($"-{friend.Username}");
                }
            }

            string result = friendsList.ToString().TrimEnd();

            return result;
        }
    }
}