namespace _02ConvertFromBaseNToBase10
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();

            int baseN = int.Parse(input[0]);
            char[] base10 = input[1].ToCharArray();

            BigInteger result = new BigInteger(0);

            for (int i = 0; i < base10.Length; i++)
            {
                int current = (int)Char.GetNumericValue(base10[i]);
                result += current * BigInteger.Pow(baseN, base10.Length - i - 1);
            }

            Console.WriteLine(result);
        }
    }
}