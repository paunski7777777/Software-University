using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class ForceBook
{
    public static void Main()
    {
        var forces = new Dictionary<string, List<string>>();
        string pattern = @"(.+)( \| | -> )(.+)";

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Lumpawaroo")
        {
            Match matches = Regex.Match(input, pattern);

            string forceSide = string.Empty;
            string forceUser = string.Empty;

            if (input.Contains("|"))
            {
                forceSide = matches.Groups[1].Value;
                forceUser = matches.Groups[3].Value;

                if (!forces.ContainsKey(forceUser))
                {
                    forces.Add(forceSide, new List<string>());
                }

                forces[forceSide].Add(forceUser);
            }

            else if (input.Contains("->"))
            {
                forceUser = matches.Groups[1].Value;
                forceSide = matches.Groups[3].Value;

                if (forces.ContainsKey(forceSide))
                {
                    if (forces[forceSide].Contains(forceUser))
                    {
                        continue;
                    }
                }

                foreach (var side in forces)
                {
                    if (side.Value.Contains(forceUser))
                    {
                        side.Value.Remove(forceUser);
                    }
                }

                if (!forces.ContainsKey(forceSide))
                {
                    forces[forceSide] = new List<string>();
                }

                forces[forceSide].Add(forceUser);

                Console.WriteLine($"{forceUser} joins the {forceSide} side!");
            }
        }

        var orderedForces = forces.Where(f => f.Value.Count > 0).OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key);

        foreach (var force in orderedForces)
        {
            string side = force.Key;
            List<string> members = force.Value;

            Console.WriteLine($"Side: {side}, Members: {members.Count}");

            foreach (var member in members.OrderBy(n => n))
            {
                Console.WriteLine($"! {member}");
            }

        }
    }
}

