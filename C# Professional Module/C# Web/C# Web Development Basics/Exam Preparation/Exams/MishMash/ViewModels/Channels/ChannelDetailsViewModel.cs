namespace MishMash.ViewModels.Channels
{
    using MishMash.Models.Enums;

    using System.Collections.Generic;

    public class ChannelDetailsViewModel
    {
        public string Name { get; set; }
        public ChannelType Type { get; set; }
        public int Followers { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Description { get; set; }

        public string ViewTags => string.Join(", ", this.Tags);
    }
}