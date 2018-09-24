namespace _06MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = 0;
            int len = 1;
            int max = 0;
            int pos = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[max])
                {
                    pos++;

                    if (pos > len)
                    {
                        len = pos;
                        start = max;
                    }
                }
                else
                {
                    pos = 1;
                    max = i;
                }
            }

            for (int i = start; i < start + len; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}