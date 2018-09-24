using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class Team
{
    public int Points { get; set; }
    public int Goals { get; set; }

    public Team(int points, int goals)
    {
        this.Points = points;
        this.Goals = goals;
    }
}
class FootballLeague
{
    static void Main()
    {
        string key = Console.ReadLine();
        string input = Console.ReadLine();

        string escapedKey = Regex.Escape(key);
        string pattern = string.Format(@"(?<={0})(?<teamA>[A-Za-z]*)(?={0})(.*)(?<={0})(?<teamB>[A-Za-z]*)(?={0})([^ ]+) (?<scoreA>\d+):(?<scoreB>\d+)", escapedKey);

        Regex game = new Regex(pattern);

        var teams = new Dictionary<string, Team>();

        while (input != "final")
        {
            Match match = game.Match(input);

            string teamA = Reverse(match.Groups["teamA"].Value).ToUpper();
            string teamB = Reverse(match.Groups["teamB"].Value).ToUpper();
            int scoreA = int.Parse(match.Groups["scoreA"].Value);
            int scoreB = int.Parse(match.Groups["scoreB"].Value);
#if DEBUG
            Console.WriteLine($"{teamA} - {teamB} {scoreA}:{scoreB}");
#endif

            if (!teams.ContainsKey(teamA))
            {
                teams.Add(teamA, new Team(0, 0));
            }
            if (!teams.ContainsKey(teamB))
            {
                teams.Add(teamB, new Team(0, 0));
            }

            teams[teamA].Goals += scoreA;
            teams[teamB].Goals += scoreB;

            if (scoreA > scoreB)
            {
                teams[teamA].Points += 3;
            }
            else if (scoreA < scoreB)
            {
                teams[teamB].Points += 3;
            }
            else if (scoreA == scoreB)
            {
                teams[teamA].Points += 1;
                teams[teamB].Points += 1;
            }

            input = Console.ReadLine();
        }

        var standings = teams
            .OrderByDescending(t => t.Value.Points)
            .ThenBy(t => t.Key);

        var topScorring = teams
            .OrderByDescending(t => t.Value.Goals)
            .ThenBy(t => t.Key)
            .Take(3);

        int position = 1;

        Console.WriteLine("League standings:");
        foreach (var team in standings)
        {
            string teamName = team.Key;
            Team stats = team.Value;

            Console.WriteLine($"{position}. {teamName} {stats.Points}");

            position++;
        }

        Console.WriteLine("Top 3 scored goals:");
        foreach (var team in topScorring)
        {
            string teamName = team.Key;
            Team stats = team.Value;

            Console.WriteLine($"- {teamName} -> {stats.Goals}");
        }
    }

    public static string Reverse(string str)
    {
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);

        return new string(arr);
    }
}

