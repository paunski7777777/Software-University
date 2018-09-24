namespace _08LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var data = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] logs = Console.ReadLine().Split().ToArray();

                string ip = logs[0];
                string user = logs[1];
                int duration = int.Parse(logs[2]);

                if (!data.ContainsKey(user))
                {
                    data.Add(user, new SortedDictionary<string, int>());
                }

                if (!data[user].ContainsKey(ip))
                {
                    data[user][ip] = 0;
                }

                data[user][ip] += duration;
            }

            foreach (var d in data)
            {
                int sum = d.Value.Values.Sum();

                Console.WriteLine($"{d.Key}: {sum} [{String.Join(", ", d.Value.Keys)}]");
            }
        }
    }
}