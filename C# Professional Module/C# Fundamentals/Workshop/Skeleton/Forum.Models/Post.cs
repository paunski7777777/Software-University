using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public ICollection<int> ReplyIds { get; set; }

        public Post(int id, string title, string content, int categoryId, IEnumerable<int> replayIds)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.ReplyIds = new List<int>();
        }
    }
}
