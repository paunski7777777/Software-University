using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PredicateParty
{
    static void Main()
    {
        var guests = Console.ReadLine().Split().ToList();
        string input = Console.ReadLine();

        while (input != "Party!")
        {
            string[] tokens = input.Split();
            string command = tokens[0];
            string criteria = tokens[1];

            if (criteria == "StartsWith")
            {
                string type = tokens[2];
                ForeachName(command, guests, n => n.StartsWith(type));
            }
            else if (criteria == "EndsWith")
            {
                string type = tokens[2];
                ForeachName(command, guests, n => n.EndsWith(type));
            }
            else if (criteria == "Length")
            {
                int type = int.Parse(tokens[2]);
                ForeachName(command, guests, n => n.Length == type);
            }

            input = Console.ReadLine();
        }

        PrintResult(guests);
    }

    private static void PrintResult(List<string> guests)
    {
        if (guests.Any())
        {
            Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }

    private static void ForeachName(string command, List<string> guest, Func<string, bool> condition)
    {
        for (int i = guest.Count - 1; i >= 0; i--)
        {
            if (condition(guest[i]))
            {
                switch (command)
                {
                    case "Double":
                        guest.Add(guest[i]);
                        break;
                    case "Remove":
                        guest.RemoveAt(i);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

