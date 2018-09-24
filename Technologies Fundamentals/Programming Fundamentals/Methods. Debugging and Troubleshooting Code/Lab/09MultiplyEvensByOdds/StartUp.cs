namespace _09MultiplyEvensByOdds
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int sum = GetMultipleOfEvensAndOdds(number);

            Console.WriteLine(sum);
        }

        private static int GetSumOfEvenDigits(int a)
        {
            int sum = 0;

            while (a > 0)
            {
                int lastDigit = a % 10;

                if (lastDigit % 2 == 0)
                {
                    sum += lastDigit;
                }

                a /= 10;
            }

            return sum;
        }

        private static int GetSumOfOddDigits(int b)
        {
            int sum = 0;

            while (b > 0)
            {
                int lastDigit = b % 10;

                if (lastDigit % 2 != 0)
                {
                    sum += lastDigit;
                }

                b /= 10;
            }

            return sum;
        }

        private static int GetMultipleOfEvensAndOdds(int n)
        {
            int sumEvens = GetSumOfEvenDigits(n);
            int sumOdds = GetSumOfOddDigits(n);

            return sumEvens * sumOdds;
        }
    }
}