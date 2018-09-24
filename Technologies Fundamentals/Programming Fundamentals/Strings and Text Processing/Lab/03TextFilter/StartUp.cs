namespace _03TextFilter
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(',', ' ').Where(w => w.Length > 0).ToArray();
            string text = Console.ReadLine();

            foreach (var word in words)
            {
                var replacement = new string('*', word.Length);
                text = text.Replace(word, replacement);
            }

            Console.WriteLine(text);
        }
    }
}