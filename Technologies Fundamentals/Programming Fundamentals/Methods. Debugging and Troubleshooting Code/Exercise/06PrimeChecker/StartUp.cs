namespace _06PrimeChecker
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            bool prime = false;

            if (n < 2)
            {
                Console.WriteLine(prime);
                return;
            }

            Console.WriteLine(IsPrime(n));
        }

        private static bool IsPrime(long n)
        {
            bool prime = true;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    prime = false;
                }
            }

            return prime;
        }
    }
}