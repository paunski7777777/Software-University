namespace MishMash.ViewModels.Home
{
    using MishMash.ViewModels.Channels;

    using System.Collections.Generic;

    public class IndexLoggedInViewModel
    {
        public IEnumerable<FollowedChannelViewModel> YourChannels { get; set; }
        public IEnumerable<FollowedChannelViewModel> Suggested { get; set; }
        public IEnumerable<FollowedChannelViewModel> SeeOther { get; set; }
    }
}