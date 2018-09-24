namespace _06SquareNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> result = new List<int>();

            foreach (int n in numbers)
            {
                if (Math.Sqrt(n) == (int)Math.Sqrt(n))
                {
                    result.Add(n);
                }
            }

            result.Sort((a, b) => b.CompareTo(a));

            Console.WriteLine(string.Join(" ", result));
        }
    }
}