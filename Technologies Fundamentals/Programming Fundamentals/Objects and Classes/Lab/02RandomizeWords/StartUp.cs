namespace _02RandomizeWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine().Split().ToList();

            Random rnd = new Random();

            for (int i = 0; i < input.Count; i++)
            {
                int first = rnd.Next(0, input.Count);
                int second = rnd.Next(0, input.Count);

                string change = input[first];
                input[first] = input[second];
                input[second] = change;
            }

            Console.WriteLine(string.Join("\n", input));
        }
    }
}