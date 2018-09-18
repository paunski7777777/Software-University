using System;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;
    public Engine()
    {
        this.raceTower = new RaceTower();
    }
    public void Run()
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        raceTower.SetTrackInfo(lapsNumber, trackLength);

        while (!this.raceTower.IsRaceOver)
        {
            var commandArgs = Console.ReadLine().Split().ToList();
            string command = commandArgs[0];
            var methodArgs = commandArgs.Skip(1).ToList();

            switch (command)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(methodArgs);
                    break;

                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;

                case "CompleteLaps":
                    string result = this.raceTower.CompleteLaps(methodArgs);

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    break;

                case "Box":
                    this.raceTower.DriverBoxes(methodArgs);
                    break;

                case "ChangeWeather":
                    this.raceTower.ChangeWeather(methodArgs);
                    break;
            }
        }
    }
}

