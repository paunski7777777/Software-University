namespace _07PrimesInGivenRange
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            List<int> primes = FindPrimesInGivenRange(start, end);

            Console.WriteLine(string.Join(", ", primes));
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

        private static List<int> FindPrimesInGivenRange(int start, int end)
        {
            List<int> list = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    list.Add(i);
                }
            }

            return list;
        }
    }
}