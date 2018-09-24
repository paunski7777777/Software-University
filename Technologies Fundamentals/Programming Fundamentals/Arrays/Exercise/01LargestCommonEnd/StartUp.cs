namespace _01LargestCommonEnd
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();

            int leftCount = FindMax(arr1, arr2);
            Array.Reverse(arr1);

            arr2 = arr2.Reverse().ToArray();
            int rightCount = FindMax(arr1, arr2);

            Console.WriteLine($"{Math.Max(leftCount, rightCount)}");
        }

        private static int FindMax(string[] arr1, string[] arr2)
        {
            int min = Math.Min(arr1.Length, arr2.Length);
            int count = 0;

            for (int i = 0; i < min; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}