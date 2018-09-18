using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Inferno3
{
    static void Main()
    {
        var gems = Console.ReadLine().Split().Select(int.Parse).ToList();
        var filters = new Dictionary<string, Func<List<int>, List<int>>>();
        string input = Console.ReadLine();

        while (input != "Forge")
        {
            ParsCommand(filters, input);

            input = Console.ReadLine();
        }

        gems = Filter(gems, filters);

        Console.WriteLine(string.Join(" ", gems));
    }

    private static List<int> Filter(List<int> gems, Dictionary<string, Func<List<int>, List<int>>> filters)
    {
        var filtered = new List<int>();

        foreach (var f in filters)
        {
            var filter = f.Value;
            filtered.AddRange(filter(gems));
        }

        gems = gems.Where(gem => !filtered.Contains(gem)).ToList();
        return gems;
    }

    private static void ParsCommand(Dictionary<string, Func<List<int>, List<int>>> filters, string input)
    {
        string[] tokens = input.Split(';');
        string command = tokens[0];
        string type = tokens[1];
        int parameter = int.Parse(tokens[2]);

        string dicKey = $"{type} {parameter}";

        if (command == "Exclude")
        {
            filters[dicKey] = CreateFunction(type, parameter);
        }
        else if (command == "Reverse")
        {
            filters.Remove(dicKey);
        }
    }

    private static Func<List<int>, List<int>> CreateFunction(string type, int parameter)
    {
        switch (type)
        {
            case "Sum Left":
                return gems => gems.Where(gem =>
                {
                    int index = gems.IndexOf(gem);
                    int left = index > 0 ? gems[index - 1] : 0;
                    return gem + left == parameter;
                }).ToList();

            case "Sum Right":
                return gems => gems.Where(gem =>
                {
                    int index = gems.IndexOf(gem);
                    int right = index < gems.Count - 1 ? gems[index + 1] : 0;
                    return gem + right == parameter;
                }).ToList();

            case "Sum Left Right":
                return gems => gems.Where(gem =>
                {
                    int index = gems.IndexOf(gem);
                    int left = index > 0 ? gems[index - 1] : 0;
                    int right = index < gems.Count - 1 ? gems[index + 1] : 0;
                    return gem + left + right == parameter;
                }).ToList();

            default:
                throw new ArgumentException();
        }
    }
}

