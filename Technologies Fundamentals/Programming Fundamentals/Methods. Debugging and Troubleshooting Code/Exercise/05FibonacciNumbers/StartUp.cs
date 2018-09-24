namespace _05FibonacciNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(FibonacciNumber(n));
        }

        private static int FibonacciNumber(int n)
        {
            int f0 = 1;
            int f1 = 1;

            for (int i = 0; i < n - 1; i++)
            {
                int fNext = f0 + f1;

                f0 = f1;
                f1 = fNext;
            }

            return f1;
        }
    }
}