namespace Forum.App.ViewModels
{
    using Forum.App.Contracts;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string author, string text)
            : base(text)
        {
            Author = author;
        }

        public string Author { get; }
    }
}
