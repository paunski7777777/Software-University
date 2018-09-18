namespace Forum.App.ViewModels
{
    using Forum.App.Contracts;

    public class CategoryInfoViewModel : ICategoryInfoViewModel
    {
        public int Id { get; }
        public string Name { get; }
        public int PostCount { get; }

        public CategoryInfoViewModel(int id, string name, int postCount)
        {
            this.Id = id;
            this.Name = name;
            this.PostCount = postCount;
        }
    }
}
