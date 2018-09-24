namespace _18DifferentIntegersSize
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());

            Console.WriteLine(CanFitIn(n));
        }

        private static string CanFitIn(BigInteger n)
        {

            if (n <= long.MaxValue)
            {
                Console.WriteLine("{0} can fit in:", n);

                if (n >= sbyte.MinValue && n <= sbyte.MaxValue)
                {
                    Console.WriteLine("* sbyte");
                }
                if (n >= byte.MinValue && n <= byte.MaxValue)
                {
                    Console.WriteLine("* byte");
                }
                if (n >= short.MinValue && n <= short.MaxValue)
                {
                    Console.WriteLine("* short");
                }
                if (n >= ushort.MinValue && n <= ushort.MaxValue)
                {
                    Console.WriteLine("* ushort");
                }
                if (n >= int.MinValue && n <= int.MaxValue)
                {
                    Console.WriteLine("* int");
                }
                if (n >= uint.MinValue && n <= uint.MaxValue)
                {
                    Console.WriteLine("* uint");
                }
                if (n >= long.MinValue && n <= long.MaxValue)
                {
                    Console.WriteLine("* long");
                }
            }
            else
            {
                Console.WriteLine("{0} can't fit in any type", n);
            }

            string output = string.Empty;
            return output;
        }
    }
}