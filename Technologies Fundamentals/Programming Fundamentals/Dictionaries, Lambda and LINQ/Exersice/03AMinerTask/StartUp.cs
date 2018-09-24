namespace _03AMinerTask
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var sequence = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "stop")
            {
                int n = int.Parse(Console.ReadLine());

                if (!sequence.ContainsKey(input))
                {
                    sequence.Add(input, 0);
                }

                sequence[input] += n;

                input = Console.ReadLine();
            }

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}