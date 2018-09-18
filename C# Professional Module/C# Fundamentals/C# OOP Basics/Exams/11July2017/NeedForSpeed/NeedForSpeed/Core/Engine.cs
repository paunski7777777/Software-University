using System;
using System.Linq;

public class Engine
{
    private CarManager carManager;
    public Engine()
    {
        this.carManager = new CarManager();
    }
    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            string[] tokens = input.Split();
            ParseCommands(tokens);
        }
    }

    private void ParseCommands(string[] tokens)
    {
        string command = tokens[0];

        switch (command)
        {
            case "register":
                int id = int.Parse(tokens[1]);
                string type = tokens[2];
                string brand = tokens[3];
                string model = tokens[4];
                int yearOfProduction = int.Parse(tokens[5]);
                int horsepower = int.Parse(tokens[6]);
                int acceleration = int.Parse(tokens[7]);
                int suspension = int.Parse(tokens[8]);
                int durability = int.Parse(tokens[9]);

                this.carManager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;

            case "check":
                int checkId = int.Parse(tokens[1]);
                Console.WriteLine(this.carManager.Check(checkId));
                break;

            case "open":
                int openId = int.Parse(tokens[1]);
                string openType = tokens[2];
                int length = int.Parse(tokens[3]);
                string route = tokens[4];
                int prizePool = int.Parse(tokens[5]);

                this.carManager.Open(openId, openType, length, route, prizePool);
                break;

            case "participate":
                int carId = int.Parse(tokens[1]);
                int raceId = int.Parse(tokens[2]);

                this.carManager.Participate(carId, raceId);
                break;

            case "start":
                int startId = int.Parse(tokens[1]);

                Console.WriteLine(this.carManager.Start(startId));
                break;

            case "park":
                int parkId = int.Parse(tokens[1]);

                this.carManager.Park(parkId);
                break;

            case "unpark":
                int unparkId = int.Parse(tokens[1]);

                this.carManager.Unpark(unparkId);
                break;

            case "tune":
                int tuneIndex = int.Parse(tokens[1]);
                string addOn = tokens[2];

                this.carManager.Tune(tuneIndex, addOn);
                break;
        }
    }
}

