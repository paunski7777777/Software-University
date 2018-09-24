namespace _03LastKNumbersSums
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] arr = new long[n];
            arr[0] = 1;

            for (int i = 1; i < n; i++)
            {
                long sum = 0;

                for (int j = i - k; j <= i - 1; j++)
                {
                    if (j >= 0)
                    {
                        sum += arr[j];
                    }
                }

                arr[i] = sum;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}