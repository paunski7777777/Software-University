namespace _06UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var userIP = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split();

                string ip = tokens[0].Split('=')[1];
                string user = tokens[2].Split('=')[1];

                if (!userIP.ContainsKey(user))
                {
                    userIP.Add(user, new Dictionary<string, int>());
                }
                if (!userIP[user].ContainsKey(ip))
                {
                    userIP[user][ip] = 0;
                }

                userIP[user][ip]++;

                input = Console.ReadLine();
            }

            foreach (var item in userIP.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key + ":");
                Console.WriteLine(string.Join(", ", item.Value.Select(x => $"{x.Key} => {x.Value}")) + ".");
            }
        }
    }
}