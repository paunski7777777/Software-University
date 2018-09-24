namespace _08UpgradedMatcher
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] products = Console.ReadLine().Split().ToArray();
            long[] quantities = Console.ReadLine().Split().Select(long.Parse).ToArray();
            decimal[] prices = Console.ReadLine().Split().Select(decimal.Parse).ToArray();


            string[] product = Console.ReadLine().Split().ToArray();

            while (product[0] != "done")
            {
                long quantity = long.Parse(product[1]);
                int index = Array.IndexOf(products, product[0]);
                int length = quantities.Length;

                if (index >= length)
                {
                    quantities = new long[length + index];

                    for (int i = 0; i < length; i++)
                    {
                        quantities[length - 1 - i] = 0;
                    }
                }

                if (quantities[index] >= quantity)
                {
                    decimal total = (decimal)prices[index] * quantity;

                    quantities[index] -= quantity;

                    Console.WriteLine($"{product[0]} x {quantity} costs {total:f2}");
                }
                else
                {
                    Console.WriteLine($"We do not have enough {product[0]}");
                }

                product = Console.ReadLine().Split().ToArray();
            }
        }
    }
}