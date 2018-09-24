using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RoliTheCoder
{
    static void Main()
    {
        string input = Console.ReadLine();

        var eventIDandName = new Dictionary<int, string>();
        var eventInfo = new Dictionary<string, List<string>>();

        while (input != "Time for Code")
        {
            if (input.Contains("#"))
            {
                string[] info = input.Split(new char[] { ' ', '#' }, StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(info[0]);
                string eventName = info[1];
                var participants = new List<string>();

                if (info.Length > 2)
                {
                    for (int i = 2; i < info.Length; i++)
                    {
                        participants.Add(info[i]);
                    }
                }
                if (!eventIDandName.ContainsKey(id))
                {
                    eventIDandName.Add(id, eventName);
                    eventInfo.Add(eventName, participants);
                }
                else if (eventIDandName[id] == eventName)
                {
                    eventInfo[eventName].AddRange(participants);
                }
            }

            input = Console.ReadLine();
        }

        foreach (var e in eventInfo.OrderByDescending(x => x.Value.Distinct().Count()).ThenBy(y => y.Key))
        {
            string name = e.Key;
            List<string> participants = e.Value;
            int count = participants.Distinct().Count();

            Console.WriteLine($"{name} - {count}");
            foreach (var p in participants.OrderBy(a => a).Distinct())
            {
                Console.WriteLine(p);
            }
        }
    }
}

