namespace _07SumArrays
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bigger = Math.Max(arr1.Length, arr2.Length);

            for (int i = 0; i < bigger; i++)
            {
                int sum = arr1[i % arr1.Length] + arr2[i % arr2.Length];

                Console.Write(String.Join(" ", sum) + " ");
            }
        }
    }
}