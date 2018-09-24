namespace _02AdvertisementMessage
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] phrases = "Excellent product.|Such a great product.|I always use that product.|Best product of its category.|Exceptional product|I can't live without this product".Split('|').ToArray();
            string[] events = "Now I feel good.|I have succeeded with this product.|Makes miracles.I am happy of the results!|I cannot believe but now I feel awesome.|Try it yourself, I am very satisfied.|I feel great!".Split('|').ToArray();
            string[] authors = "Diana Petya Stella Elena Katya Iva Annie Eva".Split().ToArray();
            string[] cities = "Burgas Sofia Plovdiv Varna Ruse".Split().ToArray();

            Random rnd = new Random();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{phrases[rnd.Next(phrases.Length)]} {events[rnd.Next(events.Length)]} {authors[rnd.Next(authors.Length)]} - {cities[rnd.Next(cities.Length)]}");
            }
        }
    }
}