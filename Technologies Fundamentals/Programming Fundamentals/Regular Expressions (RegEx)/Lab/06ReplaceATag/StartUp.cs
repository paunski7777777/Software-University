namespace _06ReplaceATag
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                string regex = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                string replacement = @"[URL href=$1]$2[/URL]";
                string replaced = Regex.Replace(input, regex, replacement);

                Console.WriteLine(replaced);

                input = Console.ReadLine();
            }
        }
    }
}