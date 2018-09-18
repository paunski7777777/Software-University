namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Models.Enums;
    using PhotoShare.Services.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private const int DataLength = 3;
        private const string InvalidCommandMessage = "Command ShareAlbum not valid!";

        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly IAlbumRoleService albumRoleService;

        public ShareAlbumCommand(IAlbumService albumService, IUserService userService, IAlbumRoleService albumRoleService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.albumRoleService = albumRoleService;
        }

        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            if (data.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            int albumId = int.Parse(data[0]);
            string username = data[1];
            string permission = data[2];

            var albumExist = this.albumService.Exists(albumId);

            if (!albumExist)
            {
                throw new ArgumentException(ShareAlbumMessages.AlbumNotFoundMessage);
            }

            var userExist = this.userService.Exists(username);

            if (!userExist)
            {
                throw new ArgumentException(ShareAlbumMessages.UserNotFoundMessage);
            }

            bool isValidPermission = Enum.TryParse(permission, out Role validPermission);

            if (!isValidPermission)
            {
                throw new ArgumentException(ShareAlbumMessages.InvalidPermissionMessage);
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;
            var albumName = this.albumService.ById<AlbumDto>(albumId).Name;

            this.albumRoleService.PublishAlbumRole(albumId, userId, permission);

            string result = string.Format(ShareAlbumMessages.SuccessMessage, username, albumName, permission);

            return result;
        }
    }
}