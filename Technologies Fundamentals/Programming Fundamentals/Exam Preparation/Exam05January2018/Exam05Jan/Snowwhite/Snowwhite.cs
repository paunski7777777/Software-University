using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Snowwhite
{
    static void Main()
    {
        string input = Console.ReadLine();
        var dwarfs = new Dictionary<string, int>();

        while (input != "Once upon a time")
        {
            string[] inputs = input.Split(new string[] { " <:> " }, StringSplitOptions.None);
            string name = inputs[0];
            string color = inputs[1];
            int physics = int.Parse(inputs[2]);

            string dwarf = color + ":" + name;
            if (!dwarfs.ContainsKey(dwarf))
            {
                dwarfs.Add(dwarf, physics);
            }
            else
            {
                dwarfs[dwarf] = Math.Max(dwarfs[dwarf], physics);
            }

            input = Console.ReadLine();
        }
        foreach (var d in dwarfs
            .OrderByDescending(x => x.Value)
            .ThenByDescending(x => dwarfs.Where(y => y.Key.Split(':')[0] == x.Key.Split(':')[0])
            .Count()))
        {
            string color = d.Key.Split(':')[0];
            string name = d.Key.Split(':')[1];
            int physics = d.Value;

            Console.WriteLine($"({color}) {name} <-> {physics}");
        }
    }
}
