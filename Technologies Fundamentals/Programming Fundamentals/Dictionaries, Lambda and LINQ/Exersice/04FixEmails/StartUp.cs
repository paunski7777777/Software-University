namespace _04FixEmails
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var sequence = new Dictionary<string, string>();

            string input = Console.ReadLine();

            string uk = "uk";
            string us = "us";

            while (input != "stop")
            {
                string emails = Console.ReadLine();

                if (!sequence.ContainsKey(input))
                {
                    sequence.Add(input, emails);
                }

                input = Console.ReadLine();
            }

            foreach (var item in sequence)
            {
                if (!(item.Value.EndsWith(uk)) && !(item.Value.EndsWith(us)))
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }
    }
}