namespace _04Largest3Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var sorted = numbers.OrderByDescending(x => x);
            var largest = sorted.Take(3);

            Console.WriteLine(string.Join(" ", largest));
        }
    }
}