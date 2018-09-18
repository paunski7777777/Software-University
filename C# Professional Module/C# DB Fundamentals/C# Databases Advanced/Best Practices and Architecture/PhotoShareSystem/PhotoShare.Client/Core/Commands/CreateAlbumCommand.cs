namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Models.Enums;
    using Services.Contracts;


    public class CreateAlbumCommand : ICommand
    {
        private const int DataLength = 4;
        private const string InvalidCommandMessage = "Command CreateAlbum not valid!";

        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly ITagService tagService;

        public CreateAlbumCommand(IAlbumService albumService, IUserService userService, ITagService tagService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            if (data.Length < DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string username = data[0];
            string albumTitle = data[1];
            string bgColor = data[2];
            string[] tags = data.Skip(3).ToArray();

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException(string.Format(CreateAlbumMessages.UserDoesNotExistMessage, username));
            }

            var albumExist = this.albumService.Exists(albumTitle);

            if (albumExist)
            {
                throw new ArgumentException(string.Format(CreateAlbumMessages.AlbumDoesExistMessage, albumTitle));
            }

            var isValidColor = Enum.TryParse(bgColor, out Color bgColorResult);

            if (!isValidColor)
            {
                throw new ArgumentException(string.Format(CreateAlbumMessages.ColorNotFoundMessage, bgColor));
            }

            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = tags[i].ValidateOrTransform();

                var currentTag = this.tagService.Exists(tags[i]);

                if (!currentTag)
                {
                    throw new ArgumentException(CreateAlbumMessages.TagNotFoundMessage);
                }
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            this.albumService.Create(userId, albumTitle, bgColor, tags);

            return string.Format(CreateAlbumMessages.SuccessMessage, albumTitle);
        }
    }
}