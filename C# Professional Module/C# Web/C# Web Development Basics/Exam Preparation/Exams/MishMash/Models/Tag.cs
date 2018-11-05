namespace MishMash.Models
{
    using System.Collections.Generic;

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ChannelTag> Channels { get; set; }

        public Tag()
        {
            this.Channels = new HashSet<ChannelTag>();
        }
    }
}