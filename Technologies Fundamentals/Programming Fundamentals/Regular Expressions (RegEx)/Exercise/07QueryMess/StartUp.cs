namespace _07QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string pattern1 = @"([^&=?\s]*)(?=\=)=(?<=\=)([^&=\s]*)";
            string pattern2 = @"((%20|\+)+)";

            while (input != "END")
            {
                Regex pairs = new Regex(pattern1);

                MatchCollection matches = pairs.Matches(input);

                var queries = new Dictionary<string, List<string>>();

                foreach (Match m in matches)
                {
                    string field = m.Groups[1].Value.ToString();
                    field = Regex.Replace(field, pattern2, word => " ").Trim();

                    string value = m.Groups[2].Value.ToString();
                    value = Regex.Replace(value, pattern2, word => " ").Trim();

                    if (!queries.ContainsKey(field))
                    {
                        var values = new List<string>
                        {
                            value
                        };

                        queries.Add(field, values);
                    }
                    else if (queries.ContainsKey(field))
                    {
                        queries[field].Add(value);
                    }
                }

                foreach (var q in queries)
                {
                    string key = q.Key;
                    List<string> value = q.Value;

                    Console.Write($"{key}=[{string.Join(", ", value)}]");
                }

                Console.WriteLine();

                input = Console.ReadLine();
            }
        }
    }
}