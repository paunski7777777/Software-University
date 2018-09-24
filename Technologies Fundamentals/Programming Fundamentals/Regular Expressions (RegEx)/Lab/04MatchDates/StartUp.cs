namespace _04MatchDates
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string regex = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            MatchCollection matchedDates = Regex.Matches(input, regex);

            var result = new List<string>();

            foreach (Match dates in matchedDates)
            {
                var day = dates.Groups["day"].Value;
                var month = dates.Groups["month"].Value;
                var year = dates.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}