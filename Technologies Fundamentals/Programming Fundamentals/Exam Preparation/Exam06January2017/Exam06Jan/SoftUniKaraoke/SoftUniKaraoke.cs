using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SoftUniKaraoke
{
    static void Main()
    {
        var participants = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        var songs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        string input = Console.ReadLine();

        var winners = new Dictionary<string, HashSet<string>>();

        while (input != "dawn")
        {
            string[] tokens = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string participant = tokens[0];
            string song = tokens[1];
            string award = tokens[2];

            if (songs.Contains(song) && participants.Contains(participant))
            {
                if (!winners.ContainsKey(participant))
                {
                    winners[participant] = new HashSet<string>();
                }
                winners[participant].Add(award);
            }

            input = Console.ReadLine();
        }

        if (winners.Count == 0)
        {
            Console.WriteLine("No awards");
        }

        foreach (var winner in winners.OrderByDescending(a => a.Value.Count()))
        {
            string name = winner.Key;
            HashSet<string> awards = winner.Value;
            int awardsCount = winner.Value.Count();

            Console.WriteLine($"{name}: {awardsCount} awards");
            foreach (var award in awards.OrderBy(b => b))
            {
                Console.WriteLine($"--{award}");
            }
        }
    }
}

