namespace _10PairsByDifference
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());

            int elements = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = numbers.Length - 1; j >= 0; j--)
                {
                    if ((numbers[i] - numbers[j]) == diff)
                    {
                        elements++;
                    }
                }
            }

            Console.WriteLine(elements);
        }
    }
}