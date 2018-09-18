namespace Forum.App.Commands
{
    using Forum.App.Contracts;
    using System;

    public class PostCommand : ICommand
    {
        private IPostService postService;
        private ISession session;
        private IMenuFactory menuFactory;
        public PostCommand(IPostService postService, ISession session, IMenuFactory menuFactory)
        {
            this.postService = postService;
            this.session = session;
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params string[] args)
        {
            string title = args[0];
            string category = args[1];
            string content = args[2];

            bool validTitle = !string.IsNullOrWhiteSpace(title);
            bool validCategory = !string.IsNullOrWhiteSpace(category);
            bool validContent = !string.IsNullOrWhiteSpace(content);

            if (!validTitle || !validCategory || !validContent)
            {
                throw new ArgumentException("All fields must be filled!");
            }

            int postId = this.postService.AddPost(this.session.UserId, title, category, content);

            IMenu menu = this.menuFactory.CreateMenu("ViewPostMenu");

            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}
