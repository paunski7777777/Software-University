using System;
using System.Collections.Generic;
using System.Linq;

public class MOBAChallenger
{
    public static void Main()
    {
        var playerPool = new Dictionary<string, Dictionary<string, int>>();
        var positions1 = new List<string>();
        var positions2 = new List<string>();

        string input;
        while ((input = Console.ReadLine()) != "Season end")
        {

            if (input.Contains("->"))
            {
                string[] tokens = input.Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string position = tokens[1];
                int skill = int.Parse(tokens[2]);

                if (!playerPool.ContainsKey(name))
                {
                    playerPool.Add(name, new Dictionary<string, int>());
                }
                if (!playerPool[name].ContainsKey(position))
                {
                    playerPool[name].Add(position, skill);
                }
                if (playerPool[name][position] < skill)
                {
                    playerPool[name][position] = skill;
                }
            }
            else
            {
                string[] tokens = input.Split(new[] { " vs " }, StringSplitOptions.RemoveEmptyEntries);
                string firstPlayer = tokens[0];
                string secondPlayer = tokens[1];


                if (playerPool.ContainsKey(firstPlayer) && playerPool.ContainsKey(secondPlayer))
                {
                    positions1.Add(playerPool[firstPlayer].First().Key);
                    positions2.Add(playerPool[secondPlayer].First().Key);
                    bool isThereSamePosition = false;

                    foreach (var p1 in positions1)
                    {
                        foreach (var p2 in positions2)
                        {
                            if (p1 == p2)
                            {
                                isThereSamePosition = true;
                            }
                        }
                    }

                    if (isThereSamePosition)
                    {
                        var totalSkillForFirstPlayer = playerPool[firstPlayer].Values.Sum();
                        var totalSkillForSecondPlayer = playerPool[secondPlayer].Values.Sum();

                        if (totalSkillForFirstPlayer > totalSkillForSecondPlayer)
                        {
                            playerPool.Remove(secondPlayer);
                        }
                        else if (totalSkillForSecondPlayer > totalSkillForFirstPlayer)
                        {
                            playerPool.Remove(firstPlayer);
                        }
                    }
                }
            }
        }

        var ordered = playerPool.OrderByDescending(s => s.Value.Values.Sum()).ThenBy(n => n.Key);

        foreach (var player in ordered)
        {
            string name = player.Key;
            var values = player.Value;
            int totalSkill = 0;
            var skillValue = player.Value.Values.Sum();
            totalSkill += skillValue;

            Console.WriteLine($"{name}: {totalSkill} skill");
            foreach (var value in values.OrderByDescending(s => s.Value).ThenBy(p => p.Key))
            {
                string position = value.Key;
                int skill = value.Value;

                Console.WriteLine($"- {position} <::> {skill}");
            }
        }
    }
}