using System;
using System.Collections.Generic;
using System.Linq;

class CubicAssault
{
    static void Main()
    {
        var regions = new Dictionary<string, Dictionary<string, long>>();
        var meteors = new List<string>() { "Green", "Red", "Black" };

        string input;
        while ((input = Console.ReadLine()) != "Count em all")
        {
            string[] tokens = input.Split(new[] { " -> "}, StringSplitOptions.RemoveEmptyEntries);
            string regionName = tokens[0];
            string meteorType = tokens[1];
            int meteorCount = int.Parse(tokens[2]);

            if (!regions.ContainsKey(regionName))
            {
                regions.Add(regionName, new Dictionary<string, long>() { { "Green", 0 }, { "Red", 0 }, { "Black", 0 } });
            }

            regions[regionName][meteorType] += meteorCount;

            for (int i = 0; i < meteors.Count - 1; i++)
            {
                long nextTypeCount = regions[regionName][meteors[i]] / 1000000;

                if (nextTypeCount > 0)
                {
                    regions[regionName][meteors[i + 1]] += nextTypeCount;
                    regions[regionName][meteors[i]] %= 1000000;
                }
            }
        }

        var ordered = regions
            .OrderByDescending(x => x.Value["Black"])
            .ThenBy(x => x.Key.Length)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var region in ordered)
        {
            Console.WriteLine(region.Key);
            foreach (var type in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"-> {type.Key} : {type.Value}");
            }
        }
    }
}

