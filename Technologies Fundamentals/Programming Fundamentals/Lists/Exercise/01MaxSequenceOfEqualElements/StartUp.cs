namespace _01MaxSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int start = 0;
            int length = 1;
            int bestStart = 0;
            int bestLength = 1;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[bestStart])
                {
                    bestLength++;

                    if (bestLength > length)
                    {
                        length = bestLength;
                        start = bestStart;
                    }
                }
                else
                {
                    bestLength = 1;
                    bestStart = i;
                }
            }

            for (int i = start; i < start + length; i++)
            {
                Console.Write(string.Join(" ", numbers[i]) + " ");
            }
        }
    }
}