using System;
using System.Linq;

public class TseamAccount
{
    public static void Main()
    {
        var games = Console.ReadLine().Split().ToList();

        string input;
        while ((input = Console.ReadLine()) != "Play!")
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            if (command == "Install")
            {
                string gameToInstall = tokens[1];

                if (!games.Contains(gameToInstall))
                {
                    games.Insert(games.Count, gameToInstall);
                }
            }
            else if (command == "Uninstall")
            {
                string gameToUninstall = tokens[1];

                if (games.Contains(gameToUninstall))
                {
                    games.Remove(gameToUninstall);
                }
            }
            else if (command == "Update")
            {
                string gameToUpdate = tokens[1];

                if (games.Contains(gameToUpdate))
                {
                    games.Remove(gameToUpdate);
                    games.Insert(games.Count, gameToUpdate);
                }
            }
            else if (command == "Expansion")
            {
                var gamesForExpansion = input.Split(" -".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string gameToExpand = gamesForExpansion[1];
                string expansion = gamesForExpansion[2];
                if (games.Contains(gameToExpand))
                {
                    string result = $"{gameToExpand}:{expansion}";
                    games.Insert(games.IndexOf(gameToExpand) + 1, result);
                }
            }
        }

        Console.WriteLine(string.Join(" ", games));
    }
}