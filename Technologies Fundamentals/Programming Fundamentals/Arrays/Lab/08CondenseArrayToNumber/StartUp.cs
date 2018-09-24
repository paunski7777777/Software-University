namespace _08CondenseArrayToNumber
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int count = arr.Length;

            while (count > 1)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i] + arr[i + 1];
                }

                count--;
            }

            Console.WriteLine(arr[0]);
        }
    }
}