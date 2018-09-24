namespace _02OddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().ToLower().Split().ToArray();

            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (count.ContainsKey(word))
                {
                    count[word]++;
                }
                else
                {
                    count[word] = 1;
                }
            }

            List<string> result = new List<string>();

            foreach (var item in count)
            {
                if (item.Value % 2 != 0)
                {
                    result.Add(item.Key);
                }
            }

            Console.WriteLine(String.Join(", ", result));
        }
    }
}