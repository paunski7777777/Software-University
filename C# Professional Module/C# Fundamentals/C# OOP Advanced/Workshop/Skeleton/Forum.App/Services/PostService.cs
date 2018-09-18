namespace Forum.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.Contracts;
    using Forum.App.ViewModels;
    using Forum.Data;
    using Forum.DataModels;

    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            User author = this.forumData.Users.FirstOrDefault(u => u.Id == userId);

            if (author == null)
            {
                throw new ArgumentException($"User with ID {userId} not found!");
            }

            int postId = this.forumData.Posts.LastOrDefault()?.Id + 1 ?? 1;
            Category category = this.EnsureCategory(postCategory);
            Post post = new Post(postId, postTitle, postContent, category.Id, userId, new List<int>());

            this.forumData.Posts.Add(post);
            author.Posts.Add(postId);
            category.Posts.Add(postId);
            this.forumData.SaveChanges();

            return postId;

        }

        private Category EnsureCategory(string postCategory)
        {
            Category category = this.forumData.Categories.FirstOrDefault(c => c.Name == postCategory);

            if (category == null)
            {
                int id = this.forumData.Categories.LastOrDefault()?.Id + 1 ?? 1;
                category = new Category(id, postCategory, new List<int>());
                this.forumData.Categories.Add(category);
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            Post post = this.forumData.Posts.Find(p => p.Id == postId);
            User author = this.userService.GetUserById(userId);

            int replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;

            Reply reply = new Reply(replyId, replyContents, userId, postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);
            this.forumData.SaveChanges();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories = this.forumData.Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData.Categories
                .FirstOrDefault(c => c.Id == categoryId).Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with ID {categoryId} not found!");
            }

            return categoryName;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            IEnumerable<IPostInfoViewModel> posts = this.forumData.Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return posts;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            Post post = this.forumData.Posts
                .FirstOrDefault(p => p.Id == postId);

            if (post == null)
            {
                throw new ArgumentException($"Post with ID {postId} not found!");
            }

            string author = this.userService.GetUserName(post.AuthorId);

            IPostViewModel postViewModel = new PostViewModel(post.Title, author, post.Content, this.GetPostReplies(postId));

            return postViewModel;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            return this.forumData.Replies
                .Where(r => r.PostId == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));
        }
    }
}
