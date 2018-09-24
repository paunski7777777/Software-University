namespace _13Factorial
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());

            BigInteger fact = 1;

            do
            {
                fact *= n;
                n--;
            }
            while (n > 1);

            Console.WriteLine(fact);
        }
    }
}