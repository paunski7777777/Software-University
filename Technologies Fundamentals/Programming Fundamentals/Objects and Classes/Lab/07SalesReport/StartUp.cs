namespace _07SalesReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Sale[] sales = new Sale[n];

            for (int i = 0; i < n; i++)
            {
                sales[i] = ReadSale();
            }

            SortedDictionary<string, decimal> salesByTown = new SortedDictionary<string, decimal>();

            foreach (Sale item in sales)
            {
                if (!salesByTown.ContainsKey(item.Town))
                {
                    salesByTown.Add(item.Town, 0);
                }

                salesByTown[item.Town] += item.Price * item.Quantity;
            }

            foreach (var town in salesByTown)
            {
                Console.WriteLine($"{town.Key} -> {town.Value:f2}");
            }
        }

        private static Sale ReadSale()
        {
            string[] sales = Console.ReadLine().Split().ToArray();

            string town1 = sales[0];
            string product1 = sales[1];
            decimal price1 = decimal.Parse(sales[2]);
            decimal quantity1 = decimal.Parse(sales[3]);

            return new Sale() { Town = town1, Product = product1, Price = price1, Quantity = quantity1 };
        }

        public class Sale
        {
            public string Town { get; set; }
            public string Product { get; set; }
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }

        }
    }
}