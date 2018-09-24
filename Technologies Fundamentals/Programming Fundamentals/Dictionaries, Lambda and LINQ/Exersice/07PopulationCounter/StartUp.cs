namespace _07PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var dict = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();

            while (input != "report")
            {
                string[] parameters = input.Split('|');

                string city = parameters[0];
                string country = parameters[1];
                long population = long.Parse(parameters[2]);

                if (!dict.ContainsKey(country))
                {
                    dict.Add(country, new Dictionary<string, long>());
                    dict[country].Add(city, population);
                }
                else
                {
                    if (!dict[country].ContainsKey(city))
                    {
                        dict[country].Add(city, population);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var country in dict.OrderByDescending(n => n.Value.Values.Sum()))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");

                foreach (var city in country.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}