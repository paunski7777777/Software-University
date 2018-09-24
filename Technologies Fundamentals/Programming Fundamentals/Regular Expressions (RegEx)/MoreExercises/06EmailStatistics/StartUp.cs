namespace _06EmailStatistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^([A-Za-z]{5,})@([a-z]{3,})(.com|.bg|.org)$";

            var emails = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match m in matches)
                {
                    string username = m.Groups[1].ToString();
                    string mail = m.Groups[2].ToString();
                    string domain = m.Groups[3].ToString();

                    string key = mail + domain;

                    if (!emails.ContainsKey(key))
                    {
                        emails.Add(key, new List<string>());
                    }
                    if (!emails[key].Contains(username))
                    {
                        emails[key].Add(username);
                    }
                }
            }

            foreach (var e in emails.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{e.Key}:");

                foreach (var u in e.Value)
                {
                    Console.WriteLine($"### {u}");
                }
            }
        }
    }
}