namespace Forum.App.Factories
{
	using Contracts;
    using Forum.App.Models;

    public class TextAreaFactory : ITextAreaFactory
	{
		public ITextInputArea CreateTextArea(IForumReader reader, int x, int y, bool isPost = true)
		{
            ITextInputArea textInputArea = new TextInputArea(reader, x, y, isPost);
			return textInputArea;
		}
	}
}
