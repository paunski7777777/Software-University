namespace Forum.App.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class ContentViewModel
    {
        private const int LineLenght = 37;
        public string[] Content { get; }

        protected ContentViewModel(string text)
        {
            this.Content = this.GetLines(text);
        }

        private string[] GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i += LineLenght)
            {
                char[] row = contentChars.Skip(i).Take(LineLenght).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines.ToArray();
        }
    }
}
