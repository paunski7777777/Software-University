using MishMash.Models.Enums;

namespace MishMash.ViewModels.Channels
{
    public class FollowedChannelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ChannelType Type { get; set; }
        public int Followers { get; set; }
    }
}