using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AnonymousCache
{
    static void Main()
    {
        string input = Console.ReadLine();
        var data = new Dictionary<string, Dictionary<string, long>>();
        var cache = new List<string>();

        while (input != "thetinggoesskrra")
        {
            string[] tokens = input.Split("->| ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 1)
            {
                string dataSet = tokens[0];
                cache.Add(dataSet);
            }
            else
            {
                string dataKey = tokens[0];
                long dataSize = long.Parse(tokens[1]);
                string dataSet = tokens[2];

                if (!data.ContainsKey(dataSet))
                {
                    data.Add(dataSet, new Dictionary<string, long>());
                }
                data[dataSet][dataKey] = dataSize;
            }

            input = Console.ReadLine();
        }

        if (cache.Count > 0)
        {
            var result = data.OrderByDescending(x => x.Value.Sum(y => y.Value)).First();

            Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Sum(x => x.Value)}");

            foreach (var r in result.Value)
            {
                Console.WriteLine($"$.{r.Key}");
            }
        }
    }
}

