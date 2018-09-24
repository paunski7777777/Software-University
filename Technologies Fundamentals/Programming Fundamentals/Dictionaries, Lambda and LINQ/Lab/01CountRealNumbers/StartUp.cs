namespace _01CountRealNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (var n in numbers)
            {
                if (counts.ContainsKey(n))
                {
                    counts[n]++;
                }
                else
                {
                    counts[n] = 1;
                }
            }

            foreach (var c in counts.Keys)
            {
                Console.WriteLine($"{c} -> {counts[c]}");
            }
        }
    }
}