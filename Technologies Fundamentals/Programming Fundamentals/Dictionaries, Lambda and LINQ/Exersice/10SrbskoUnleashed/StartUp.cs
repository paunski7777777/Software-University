namespace _10SrbskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var srbsko = new Dictionary<string, Dictionary<string, long>>();

            while (input != "End")
            {
                var tokens = input.Split('@');

                if (tokens.Length != 2)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!tokens[0].EndsWith(" "))
                {
                    input = Console.ReadLine();
                    continue;
                }

                var right = tokens[1].Split();

                if (right.Length < 3)
                {
                    input = Console.ReadLine();
                    continue;
                }

                long price;
                long count;

                if (!long.TryParse(right[right.Length - 1], out price))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!long.TryParse(right[right.Length - 2], out count))
                {
                    input = Console.ReadLine();
                    continue;
                }

                var singer = tokens[0].Trim();
                var venue = string.Empty;
                long total = price * count;

                for (int i = 0; i < right.Length - 2; i++)
                {
                    venue += right[i] + " ";
                }

                venue = venue.Trim();

                if (!srbsko.ContainsKey(venue))
                {
                    srbsko[venue] = new Dictionary<string, long>();
                }

                if (!srbsko[venue].ContainsKey(singer))
                {
                    srbsko[venue][singer] = 0;
                }

                srbsko[venue][singer] += total;

                input = Console.ReadLine();
            }

            foreach (var venueAndSinger in srbsko)
            {
                string venue = venueAndSinger.Key;
                Dictionary<string, long> singers = venueAndSinger.Value;

                Console.WriteLine(venue);

                foreach (var singerAndPrice in singers.OrderByDescending(s => s.Value))
                {
                    string singer = singerAndPrice.Key;
                    long totalPrice = singerAndPrice.Value;

                    Console.WriteLine($"#  {singer} -> {totalPrice}");
                }
            }
        }
    }
}