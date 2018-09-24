namespace _09TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            CreateTeams(n, teams);
            AddToTeams(teams);
            PrintTeams(teams);
        }

        private static void PrintTeams(List<Team> teams)
        {
            foreach (var t in teams.Where(m => m.Members.Count > 0)
                                   .OrderByDescending(m => m.Members.Count)
                                   .ThenBy(m => m.TeamName))
            {
                Console.WriteLine($"{t.TeamName}");
                Console.WriteLine($"- {t.Creator}");

                foreach (var u in t.Members.OrderBy(a => a))
                {
                    Console.WriteLine($"-- {u}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in teams.Where(t => t.Members.Count < 1).OrderBy(t => t.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }

        private static void AddToTeams(List<Team> teams)
        {
            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] input1 = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

                string user = input1[0];
                string team = input1[1];

                bool TeamExist = false;
                bool UserIsAlreadyInATeam = false;
                bool UserIsCreatorOfATeam = false;

                foreach (var t in teams)
                {
                    if (t.TeamName == team)
                    {
                        TeamExist = true;
                    }
                    if (t.Members.Contains(user))
                    {
                        UserIsAlreadyInATeam = true;
                    }
                    if (t.Creator == user)
                    {
                        UserIsCreatorOfATeam = true;
                    }
                }

                if (!TeamExist)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (UserIsAlreadyInATeam || UserIsCreatorOfATeam)
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                }
                else
                {
                    foreach (var t in teams)
                    {
                        if (t.TeamName == team)
                        {
                            t.Members.Add(user);
                        }
                    }
                }

                input = Console.ReadLine();
            }
        }
        private static void CreateTeams(int n, List<Team> teams)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-');

                string creatorName = input[0];
                string teamName = input[1];

                Team team = new Team
                {
                    TeamName = teamName,
                    Creator = creatorName,
                    Members = new List<string>()
                };

                bool TeamAlreadyCreated = false;
                bool UserAlreadyHasATeam = false;

                foreach (var t in teams)
                {
                    if (t.TeamName == team.TeamName)
                    {
                        TeamAlreadyCreated = true;
                    }
                    if (t.Creator == team.Creator)
                    {
                        UserAlreadyHasATeam = true;
                    }
                }

                if (TeamAlreadyCreated)
                {
                    Console.WriteLine($"Team {team.TeamName} was already created!");
                    continue;
                }
                else if (UserAlreadyHasATeam)
                {
                    Console.WriteLine($"{team.Creator} cannot create another team!");
                    continue;
                }
                else
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {team.TeamName} has been created by {team.Creator}!");
                }
            }
        }

        public class Team
        {
            public string TeamName { get; set; }
            public List<string> Members { get; set; }
            public string Creator { get; set; }
        }
    }
}