using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ThePartyReserFilMod
{
    static void Main()
    {
        var names = Console.ReadLine().Split().ToList();
        string input = Console.ReadLine();

        var filters = new List<string>();

        while (input != "Print")
        {
            string[] tokens = input.Split("; ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];

            if (command == "Add")
            {
                filters.Add($"{tokens[2]} {tokens[tokens.Length - 1]}");
            }
            else if (command == "Remove")
            {
                for (int i = 0; i < filters.Count; i++)
                {
                    var currentFilter = $"{tokens[2]} {tokens[tokens.Length - 1]}";
                    if (filters[i] == currentFilter)
                    {
                        filters.RemoveAt(i);
                    }
                }
            }

            input = Console.ReadLine();
        }

        foreach (var f in filters)
        {
            if (f.Contains("Starts"))
            {
                names = names.Where(x => !x.StartsWith(f.Split().Last())).ToList();
            }
            else if (f.Contains("Ends"))
            {
                names = names.Where(x => !x.EndsWith(f.Split().Last())).ToList();
            }
            else if (f.Contains("Length"))
            {
                names = names.Where(x => !x.Length.Equals(int.Parse(f.Split().Last()))).ToList();
            }
            else
            {
                names = names.Where(x => !x.Contains(f.Split().Last())).ToList();
            }
        }

        Console.WriteLine(string.Join(" ", names));
    }
}
