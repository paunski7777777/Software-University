namespace _14FactorialTrailing0s
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(TrailingZeroes(n));
        }

        private static int TrailingZeroes(int n)
        {
            int sum = 0;

            for (int i = n / 5; i > 0; i /= 5)
            {
                sum += i;
            }

            return sum;
        }
    }
}