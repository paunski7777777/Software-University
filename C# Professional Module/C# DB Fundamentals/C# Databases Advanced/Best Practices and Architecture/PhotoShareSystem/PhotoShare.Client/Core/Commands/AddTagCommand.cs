namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Client.Utilities.OutputMessages;
    using PhotoShare.Services.Contracts;

    using System;

    public class AddTagCommand : ICommand
    {
        private const int DataLength = 1;
        private const string InvalidCommandMessage = "Command AddTag not valid!";

        private readonly ITagService tagService;

        public AddTagCommand(ITagService tagService)
        {
            this.tagService = tagService;
        }

        public string Execute(string[] args)
        {
            if (args.Length != DataLength)
            {
                throw new InvalidOperationException(InvalidCommandMessage);
            }

            var tagName = args[0];

            var tagExists = this.tagService.Exists(tagName);

            if (tagExists)
            {
                throw new ArgumentException(string.Format(AddTagMessages.TagAlreadyExistsMessage, tagName));
            }

            tagName = tagName.ValidateOrTransform();

            var tag = this.tagService.AddTag(tagName);

            return string.Format(AddTagMessages.SuccessMessage, tagName);
        }
    }
}