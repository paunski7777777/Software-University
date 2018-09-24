namespace _02RotateAndSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            int[] sum = new int[arr.Length];

            for (int i = 0; i < rotations; i++)
            {
                int rem = arr[arr.Length - 1];

                for (int j = arr.Length - 1; j > 0; j--)
                {
                    arr[j] = arr[j - 1];
                    sum[j] += arr[j];
                }

                arr[0] = rem;
                sum[0] += arr[0];
            }

            Console.WriteLine($"{string.Join(" ", sum)}");
        }
    }
}