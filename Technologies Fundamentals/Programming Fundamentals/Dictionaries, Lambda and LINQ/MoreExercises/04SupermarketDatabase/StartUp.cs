namespace _04SupermarketDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var products = new Dictionary<string, Dictionary<decimal, decimal>>();

            string[] tokens = input.Split();

            string product = tokens[0];
            decimal price = decimal.Parse(tokens[1]);
            decimal quantity = decimal.Parse(tokens[2]);

            decimal total = 0;

            while (input != "stocked")
            {
                tokens = input.Split();

                product = tokens[0];
                price = decimal.Parse(tokens[1]);
                quantity = decimal.Parse(tokens[2]);

                if (!products.ContainsKey(product))
                {
                    products.Add(product, new Dictionary<decimal, decimal>());
                }

                if (!products[product].ContainsKey(price))
                {
                    products[product][price] = 0;
                }

                products[product][price] += quantity;


                input = Console.ReadLine();
            }

            foreach (var p in products)
            {
                var product2 = p.Key;
                var price2 = p.Value.Keys.Last();
                var quantity2 = p.Value.Values.Sum();

                total += price2 * quantity2;

                Console.WriteLine($"{product2}: ${price2} * {quantity2} = ${(price2 * quantity2):f2}");
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${total:f2}");
        }
    }
}