namespace _09ExtractMiddleElements
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = arr.Length;
            int middle = n / 2;

            if (n == 1)
            {
                Console.WriteLine("{ " + $"{String.Join(" ", arr)}" + " }");
            }
            else if (n % 2 == 0)
            {
                Console.WriteLine($"{arr[middle - 1]}, {arr[middle]}");
            }
            else
            {
                Console.WriteLine($"{arr[middle - 1]}, {arr[middle]}, {arr[middle + 1]}");
            }
        }
    }
}