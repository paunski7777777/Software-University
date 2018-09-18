namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;

    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Services.Contracts;

    public class AddTagToCommand : ICommand
    {
        private const int DataLength = 2;
        private const string InvalidCommandMessage = "Command AddTagTo not valid!";

        private readonly IAlbumTagService albumTagService;
        private readonly ITagService tagService;
        private readonly IAlbumService albumService;

        public AddTagToCommand(IAlbumTagService albumTagService, ITagService tagService, IAlbumService albumService)
        {
            this.albumTagService = albumTagService;
            this.tagService = tagService;
            this.albumService = albumService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] args)
        {
            if (args.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            string albumName = args[0];
            string tagName = args[1];
            
            var albumExists = this.albumService.Exists(albumName);
            var tagExists = this.tagService.Exists(tagName);

            if (!albumExists)
            {
                throw new ArgumentException(AddTagToMessages.AlbumNotFoundMessage);
            }

            if (!tagExists)
            {
                throw new ArgumentException(AddTagToMessages.TagNotFoundMessage);
            }
            

            var albumId = this.albumService.ByName<AlbumDto>(albumName).Id;
            var tagId = this.albumService.ByName<TagDto>(tagName).Id;

            this.albumTagService.AddTagTo(albumId, tagId);

            string result = string.Format(AddTagToMessages.SuccessMessage, tagName, albumName);

            return result;
        }
    }
}