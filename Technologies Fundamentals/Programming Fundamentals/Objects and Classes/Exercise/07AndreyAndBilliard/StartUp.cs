namespace _07AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var products = new Dictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-');

                string product = input[0];
                decimal price = decimal.Parse(input[1]);

                if (!products.ContainsKey(product))
                {
                    products.Add(product, 0);
                }

                products[product] = price;
            }

            string input2 = Console.ReadLine();

            List<Customer> customers = new List<Customer>();

            while (input2 != "end of clients")
            {
                string[] info = input2.Split('-', ',');

                string name = info[0];
                string product = info[1];
                int quantity = int.Parse(info[2]);

                if (products.ContainsKey(product))
                {
                    bool IsCustomerPresent = false;

                    Customer customer = new Customer
                    {
                        Name = name,
                        ShopList = new Dictionary<string, int>()
                    };

                    customer.ShopList.Add(product, quantity);
                    customer.Bill = customer.Bill + products[product] * quantity;

                    foreach (var c in customers)
                    {
                        if (c.Name == customer.Name)
                        {
                            IsCustomerPresent = true;

                            if (c.ShopList.ContainsKey(product))
                            {
                                c.ShopList[product] += quantity;
                            }
                            else
                            {
                                c.ShopList.Add(product, quantity);
                            }

                            c.Bill += products[product] * quantity;
                        }
                    }
                    if (!IsCustomerPresent)
                    {
                        customers.Add(customer);
                    }
                }

                input2 = Console.ReadLine();
            }

            decimal total = 0;

            foreach (var c in customers.OrderBy(s => s.Name))
            {
                Console.WriteLine(c.Name);

                foreach (var pq in c.ShopList)
                {
                    Console.WriteLine($"-- {pq.Key} - {pq.Value}");
                }

                Console.WriteLine($"Bill: {c.Bill:f2}");

                total += c.Bill;
            }

            Console.WriteLine($"Total bill: {total:f2}");
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> ShopList { get; set; }
        public decimal Bill { get; set; }
    }
}