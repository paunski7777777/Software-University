namespace _11EqualSums
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool isEqual = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int[] left = numbers.Take(i).ToArray();
                int[] right = numbers.Skip(i + 1).ToArray();

                if (left.Sum() == right.Sum())
                {
                    Console.WriteLine(i);

                    isEqual = true;
                    break;
                }
            }

            if (!isEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}