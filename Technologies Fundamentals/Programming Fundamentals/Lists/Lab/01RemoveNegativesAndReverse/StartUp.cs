namespace _01RemoveNegativesAndReverse
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

            foreach (int num in numbers)
            {
                if (num > 0)
                {
                    result.Add(num);
                }
            }

            if (result.Count < 1)
            {
                Console.WriteLine("empty");
            }
            else
            {
                result.Reverse();

                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}