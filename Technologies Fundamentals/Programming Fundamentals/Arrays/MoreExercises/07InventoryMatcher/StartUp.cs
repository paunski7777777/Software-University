namespace _07InventoryMatcher
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

            string product = Console.ReadLine();

            while (product != "done")
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (product == products[i])
                    {
                        Console.WriteLine($"{product} costs: {prices[i]}; Available quantity: {quantities[i]}");
                    }
                }

                product = Console.ReadLine();
            }
        }
    }
}