using System;
using System.Collections.Generic;
using System.Linq;

class SpeedRacing
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            string model = input[0];
            double fuelAmount = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);

            Car car = new Car(model, fuelAmount, fuelConsumption);
            cars.Add(car);
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split();
            string model = tokens[1];
            double kilometers = double.Parse(tokens[2]);

            Car carToDrive = cars.First(c => c.Model == model);

            carToDrive.Drive(kilometers);
        }

        cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.DistanceTraveled}"));
    }
}

