using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingSpree
{
    public static void Main()
    {
        try
        {
            List<Person> people = ParsePeople();
            List<Product> products = ParseProducts();

            BuyProducts(people, products);

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }

    private static List<Product> ParseProducts()
    {
        var products = new List<Product>();
        string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        foreach (var productInput in productsInput)
        {
            string[] tokens = productInput.Split('=', StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];
            double price = double.Parse(tokens[1]);

            Product product = new Product(name, price);
            products.Add(product);
        }

        return products;
    }

    private static List<Person> ParsePeople()
    {
        var people = new List<Person>();
        string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        foreach (var personInput in peopleInput)
        {
            string[] tokens = personInput.Split('=', StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            double money = double.Parse(tokens[1]);

            Person person = new Person(name, money);
            people.Add(person);
        }

        return people;
    }

    private static void BuyProducts(List<Person> people, List<Product> products)
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();
            string personName = tokens[0];
            string productName = tokens[1];

            var person = people.FirstOrDefault(p => p.Name == personName);
            var product = products.FirstOrDefault(p => p.Name == productName);

            string output = person.TryBuyProduct(product);
            Console.WriteLine(output);
        }
    }
}

