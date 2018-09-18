using System;
using System.Collections.Generic;
using System.Linq;

class RawData
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            CreateCars(cars);
        }

        string command = Console.ReadLine();

        CheckCommand(cars, command);
    }

    private static void CreateCars(List<Car> cars)
    {
        string[] input = Console.ReadLine().Split();

        string model = input[0];

        int engineSpeed = int.Parse(input[1]);
        int enginePower = int.Parse(input[2]);

        int cargoWeight = int.Parse(input[3]);
        string cargoType = input[4];

        double tire1pressure = double.Parse(input[5]);
        int tire1age = int.Parse(input[6]);
        double tire2pressure = double.Parse(input[7]);
        int tire2age = int.Parse(input[8]);
        double tire3pressure = double.Parse(input[9]);
        int tire3age = int.Parse(input[10]);
        double tire4pressure = double.Parse(input[11]);
        int tire4age = int.Parse(input[12]);

        Engine engine = new Engine(engineSpeed, enginePower);
        Cargo cargo = new Cargo(cargoWeight, cargoType);

        Tire[] tires = new Tire[4];
        tires[0] = new Tire(tire1pressure, tire1age);
        tires[1] = new Tire(tire2pressure, tire2age);
        tires[2] = new Tire(tire3pressure, tire3age);
        tires[3] = new Tire(tire4pressure, tire4age);

        Car car = new Car(model, engine, cargo, tires);

        cars.Add(car);
    }

    private static void CheckCommand(List<Car> cars, string command)
    {
        if (command == "fragile")
        {
            cars
                .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                .ToList()
                .ForEach(c => Console.WriteLine($"{c.Model}"));
        }
        else
        {
            cars
                .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                .ToList()
                .ForEach(c => Console.WriteLine($"{c.Model}"));
        }
    }
}

