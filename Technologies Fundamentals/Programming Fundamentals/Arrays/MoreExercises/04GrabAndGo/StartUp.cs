namespace _04GrabAndGo
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long n = long.Parse(Console.ReadLine());

            int index = 0;

            if (numbers.Contains(n))
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == n)
                    {
                        index = i;
                    }
                }

                Console.WriteLine(numbers.Take(index).Sum());
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}