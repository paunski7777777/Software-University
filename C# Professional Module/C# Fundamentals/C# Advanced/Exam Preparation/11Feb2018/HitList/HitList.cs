using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class HitList
{
    static void Main()
    {
        int targetIndex = int.Parse(Console.ReadLine());

        var info = new Dictionary<string, Dictionary<string, string>>();
        int index = 0;

        string input;
        while ((input = Console.ReadLine()) != "end transmissions")
        {
            string[] tokens = input.Split("=:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];

            for (int i = 1; i < tokens.Length - 1; i += 2)
            {
                string key = tokens[i];
                string value = tokens[i + 1];

                if (!info.ContainsKey(name))
                {
                    info.Add(name, new Dictionary<string, string>());
                }

                if (!info[name].ContainsKey(key))
                {
                    info[name].Add(key, value);
                }
                info[name][key] = value;
            }
        }

        string[] kill = Console.ReadLine().Split();

        Console.WriteLine($"Info on {kill[1]}:");
        foreach (var person in info[kill[1]].OrderBy(a => a.Key))
        {
            string key = person.Key;
            string value = person.Value;
            index += key.Length + value.Length;

            Console.WriteLine($"---{key}: {value}");
        }

        Console.WriteLine($"Info index: {index}");

        if (index >= targetIndex)
        {
            Console.WriteLine("Proceed");
        }
        else
        {
            Console.WriteLine($"Need {targetIndex - index} more info.");
        }
    }
}

