namespace MishMash.Models
{
    using MishMash.Models.Enums;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Channel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public ChannelType Type { get; set; }
        public virtual ICollection<ChannelTag> Tags { get; set; }
        public virtual ICollection<UserChannel> Followers { get; set; }

        public Channel()
        {
            this.Tags = new HashSet<ChannelTag>();
            this.Followers = new HashSet<UserChannel>();
        }
    }
}