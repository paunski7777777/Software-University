namespace _02ReverseArrayOfIntegers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int j = n - 1; j >= 0; j--)
            {
                Console.WriteLine(arr[j]);
            }
        }
    }
}