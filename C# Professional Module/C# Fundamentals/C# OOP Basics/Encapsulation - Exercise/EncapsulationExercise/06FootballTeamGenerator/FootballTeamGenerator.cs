using System;
using System.Collections.Generic;
using System.Linq;

public class FootballTeamGenerator
{
    public static void Main()
    {
        var teams = new List<Team>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            string teamName = tokens[1];

            try
            {
                ParseCommands(teams, tokens, command, teamName);
            }
            catch(ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }

    private static void ParseCommands(List<Team> teams, string[] tokens, string command, string teamName)
    {
        switch (command)
        {
            case "Team":
                TeamCommand(teams, teamName);
                break;
            case "Add":
                AddCommand(teams, tokens, teamName);
                break;
            case "Remove":
                RemoveCommand(teams, tokens, teamName);
                break;
            case "Rating":
                RatingCommand(teams, teamName);
                break;
        }
    }

    private static void TeamCommand(List<Team> teams, string teamName)
    {
        Team team = new Team(teamName);
        teams.Add(team);
    }

    private static void RatingCommand(List<Team> teams, string teamName)
    {
        if (teams.Any(t => t.Name == teamName))
        {
            var teamRating = teams.FirstOrDefault(t => t.Name == teamName);
            Console.WriteLine(teamRating);
        }
        else
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
    }

    private static void RemoveCommand(List<Team> teams, string[] tokens, string teamName)
    {
        string playerNameToRemove = tokens[2];
        var currentTeamRemove = teams.FirstOrDefault(t => t.Name == teamName);
        currentTeamRemove.RemovePlayer(playerNameToRemove);
    }

    private static void AddCommand(List<Team> teams, string[] tokens, string teamName)
    {
        if (teams.Any(t => t.Name == teamName))
        {
            var currentTeam = teams.FirstOrDefault(t => t.Name == teamName);

            string playerName = tokens[2];
            int endurance = int.Parse(tokens[3]);
            int sprint = int.Parse(tokens[4]);
            int dribble = int.Parse(tokens[5]);
            int passing = int.Parse(tokens[6]);
            int shooting = int.Parse(tokens[7]);

            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            currentTeam.AddPlayer(player);
        }
        else
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
    }
}

