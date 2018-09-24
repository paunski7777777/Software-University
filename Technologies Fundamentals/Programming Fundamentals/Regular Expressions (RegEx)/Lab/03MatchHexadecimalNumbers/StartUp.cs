namespace _03MatchHexadecimalNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string regex = @"\b(?:0x)?[0-9A-F]+\b";

            MatchCollection matched = Regex.Matches(input, regex);

            List<string> result = new List<string>();

            foreach (Match number in matched)
            {
                result.Add(number.Value);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}