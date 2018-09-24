namespace _01ConvertFromBase10TobaseN
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            BigInteger[] arr = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();

            BigInteger position = arr[0];
            BigInteger number = arr[1];

            string result = string.Empty;

            while (number >= 1)
            {
                result = (number % position) + result;
                number = number / position;
            }

            Console.WriteLine(result);
        }
    }
}