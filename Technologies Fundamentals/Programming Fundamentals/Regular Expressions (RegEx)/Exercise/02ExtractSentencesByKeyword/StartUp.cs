namespace _02ExtractSentencesByKeyword
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string word = Console.ReadLine();

            char[] separators = new char[] { '.', '!', '?' };
            string[] text = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string pattern = "\\b" + word + "\\b";
            Regex regex = new Regex(pattern);

            foreach (var w in text)
            {
                if (regex.IsMatch(w))
                {
                    Console.WriteLine(w.Trim());
                }
            }
        }
    }
}