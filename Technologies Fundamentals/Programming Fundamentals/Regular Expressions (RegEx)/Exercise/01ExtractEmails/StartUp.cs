namespace _01ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string regex = @"(\s[a-zA-Z0-9][\w.-]*\@[a-zA-z-]+)(\.[a-zA-Z-]+)+";

            MatchCollection matched = Regex.Matches(input, regex);

            foreach (Match emails in matched)
            {
                Console.WriteLine(emails);
            }
        }
    }
}