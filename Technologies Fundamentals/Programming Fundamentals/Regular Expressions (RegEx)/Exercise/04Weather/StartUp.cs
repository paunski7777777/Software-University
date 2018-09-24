namespace _04Weather
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var citiesWithTemp = new Dictionary<string, double>();
            var citiesWithWeath = new Dictionary<string, string>();

            string pattern = "([A-Z]{2})(\\d+\\.\\d+)([A-Za-z]+)\\|";
            string input = Console.ReadLine();

            while (input != "end")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);

                    string city = match.Groups[1].Value;
                    double temperature = double.Parse(match.Groups[2].Value);
                    string weather = match.Groups[3].Value;

                    citiesWithTemp[city] = temperature;
                    citiesWithWeath[city] = weather;
                }

                input = Console.ReadLine();
            }

            Dictionary<string, double> sorted = citiesWithTemp
                                                .OrderBy(c => c.Value)
                                                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var scity in sorted)
            {
                Console.WriteLine($"{scity.Key} => {scity.Value:f2} => {citiesWithWeath[scity.Key]}");
            }
        }
    }
}