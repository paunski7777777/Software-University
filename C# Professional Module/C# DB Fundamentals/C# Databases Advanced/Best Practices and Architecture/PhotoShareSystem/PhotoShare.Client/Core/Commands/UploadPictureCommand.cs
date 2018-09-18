namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Contracts;
    using Services.Contracts;
    using PhotoShare.Client.Utilities.OutputMessages;

    public class UploadPictureCommand : ICommand
    {
        private const int DataLength = 3;
        private const string InvalidCommandMessage = "Command UploadPicture not valid!";

        private readonly IPictureService pictureService;
        private readonly IAlbumService albumService;

        public UploadPictureCommand(IPictureService pictureService, IAlbumService albumService)
        {
            this.pictureService = pictureService;
            this.albumService = albumService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            if (data.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string albumName = data[0];
            string pictureTitle = data[1];
            string path = data[2];

            var albumExists = this.albumService.Exists(albumName);

            if (!albumExists)
            {
                throw new ArgumentException(string.Format(UploadPictureMessages.AlbumNotFound, albumName));
            }

            var albumId = this.albumService.ByName<AlbumDto>(albumName).Id;

            var picture = this.pictureService.Create(albumId, pictureTitle, path);

            string result = string.Format(UploadPictureMessages.SuccessMessage, pictureTitle, albumName);

            return result;
        }
    }
}