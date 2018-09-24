namespace _04TripleSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = 0;
            bool contains = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int a = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (i != j)
                    {
                        int b = numbers[j];
                        sum = a + b;

                        if (numbers.Contains(sum))
                        {
                            Console.WriteLine($"{a} + {b} == {sum}");

                            contains = true;
                        }
                    }
                }
            }

            if (!contains)
            {
                Console.WriteLine("No");
            }
        }
    }
}