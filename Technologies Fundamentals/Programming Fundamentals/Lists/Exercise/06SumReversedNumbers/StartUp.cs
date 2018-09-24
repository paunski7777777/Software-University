namespace _06SumReversedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                var result = numbers[i].ToString().ToList();

                result.Reverse();

                sum += int.Parse(string.Join("", result));
            }

            Console.Write(string.Join(" ", sum));
            Console.WriteLine();
        }
    }
}