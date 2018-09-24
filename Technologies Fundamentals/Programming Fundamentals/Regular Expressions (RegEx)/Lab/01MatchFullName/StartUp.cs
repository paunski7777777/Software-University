namespace _01MatchFullName
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            string name = Console.ReadLine();

            MatchCollection matched = Regex.Matches(name, regex);

            var result = new List<string>();

            foreach (Match n in matched)
            {
                result.Add(n.Value);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}