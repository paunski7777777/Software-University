namespace _07AdvertisementMessage
{
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = File.ReadAllText("input.txt");

            string[] phrases = "Excellent product.|Such a great product.|I always use that product.|Best product of its category.|Exceptional product|I can't live without this product".Split('|').ToArray();
            string[] events = "Now I feel good.|I have succeeded with this product.|Makes miracles.I am happy of the results!|I cannot believe but now I feel awesome.|Try it yourself, I am very satisfied.|I feel great!".Split('|').ToArray();
            string[] authors = "Diana Petya Stella Elena Katya Iva Annie Eva".Split().ToArray();
            string[] cities = "Burgas Sofia Plovdiv Varna Ruse".Split().ToArray();

            Random rnd = new Random();

            int n = int.Parse(input);

            for (int i = 0; i < n; i++)
            {            
                File.AppendAllText("output.txt", $"{phrases[rnd.Next(phrases.Length)].ToString()} {events[rnd.Next(events.Length)].ToString()} {authors[rnd.Next(authors.Length)].ToString()} - {cities[rnd.Next(cities.Length)].ToString()}");
                File.AppendAllText("output.txt", Environment.NewLine);
            }
        }
    }
}