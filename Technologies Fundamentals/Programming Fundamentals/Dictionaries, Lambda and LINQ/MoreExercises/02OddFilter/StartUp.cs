namespace _02OddFilter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var odd = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    odd.Add(numbers[i]);
                }
            }

            double average = odd.Average();

            for (int i = 0; i < odd.Count; i++)
            {
                if (odd[i] <= average)
                {
                    odd[i]--;
                }
                if (odd[i] >= average)
                {
                    odd[i]++;
                }
            }

            Console.WriteLine(string.Join(" ", odd));
        }
    }
}