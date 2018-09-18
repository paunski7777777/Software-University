using System;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private NationsBuilder builder;
    public Engine()
    {
        this.builder = new NationsBuilder();
        isRunning = true;
    }
    public void Run()
    {
        while (isRunning)
        {
            var tokens = Console.ReadLine().Split().ToList();
            string command = tokens[0];
            tokens.RemoveAt(0);

            switch (command)
            {
                case "Bender":
                    builder.AssignBender(tokens);
                    break;

                case "Monument":
                    builder.AssignMonument(tokens);
                    break;

                case "Status":
                    Console.WriteLine(builder.GetStatus(tokens[0]));
                    break;

                case "War":
                    builder.IssueWar(tokens[0]);
                    break;

                case "Quit":
                    Console.WriteLine(builder.GetWarsRecord());
                    isRunning = false;
                    break;
            }
        }
    }
}

