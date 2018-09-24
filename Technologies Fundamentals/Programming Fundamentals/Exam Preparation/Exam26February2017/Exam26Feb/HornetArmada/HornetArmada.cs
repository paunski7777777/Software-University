using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HornetArmada
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var legionsActivity = new Dictionary<string, long>();
        var legionsInfo = new Dictionary<string, Dictionary<string, long>>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split("=->: ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            long activity = long.Parse(input[0]);
            string legion = input[1];
            string type = input[2];
            long count = long.Parse(input[3]);

            if (!legionsInfo.ContainsKey(legion))
            {
                legionsInfo.Add(legion, new Dictionary<string, long>());
                legionsActivity.Add(legion, activity);
            }
            if (!legionsInfo[legion].ContainsKey(type))
            {
                legionsInfo[legion].Add(type, count);
            }
            else
            {
                legionsInfo[legion][type] += count;
            }
            if (legionsActivity[legion] < activity)
            {
                legionsActivity[legion] = activity;
            }
        }

        string command = Console.ReadLine();

        if (command.IndexOf('\\') != -1)
        {
            long activity = long.Parse(command.Substring(0, command.IndexOf('\\')));
            string type = command.Substring(command.IndexOf('\\') + 1);

            foreach (var li in legionsInfo.Where(i => legionsInfo[i.Key].ContainsKey(type)).OrderByDescending(l => l.Value[type]))
            {
                if (legionsActivity[li.Key] < activity)
                {
                    Console.WriteLine($"{li.Key} -> {li.Value[type]}");
                }
            }
        }
        else
        {
            foreach (var la in legionsActivity.OrderByDescending(x => x.Value))
            {
                if (legionsInfo[la.Key].ContainsKey(command))
                {
                    Console.WriteLine($"{la.Value} : {la.Key}");
                }
            }
        }
    }
}

