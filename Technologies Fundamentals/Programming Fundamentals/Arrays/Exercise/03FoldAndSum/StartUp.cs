namespace _03FoldAndSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = arr.Length / 4;

            int[] left = arr.Take(k).ToArray();
            int[] midd = arr.Skip(k).Take(k * 2).ToArray();
            int[] right = arr.Skip(k * 3).Take(k).ToArray();

            Array.Reverse(left);
            Array.Reverse(right);

            int[] result = new int[k * 2];

            for (int i = 0; i < k; i++)
            {
                result[i] = midd[i] + left[i];
                result[i + k] = midd[i + k] + right[i];
            }

            Console.WriteLine($"{String.Join(" ", result)}");
        }
    }
}