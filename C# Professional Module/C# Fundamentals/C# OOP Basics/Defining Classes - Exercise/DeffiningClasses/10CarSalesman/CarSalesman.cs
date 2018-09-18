using System;
using System.Collections.Generic;
using System.Linq;

public class CarSalesman
{
    public static void Main()
    {
        int enginesCount = int.Parse(Console.ReadLine());
        var engines = new List<Engine>();

        for (int i = 0; i < enginesCount; i++)
        {
            ParseEngines(engines);
        }

        int carsCount = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            ParseCars(engines, cars);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static void ParseCars(List<Engine> engines, List<Car> cars)
    {
        string[] carsInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string carModel = carsInfo[0];
        string carEngine = carsInfo[1];

        Car car = new Car(carModel, engines.FirstOrDefault(e => e.Model == carEngine));

        if (carsInfo.Length >= 3)
        {
            if (carsInfo[2].All(c => char.IsDigit(c)))
            {
                car.Weight = carsInfo[2];
            }
            else
            {
                car.Color = carsInfo[2];
            }
        }
        if (carsInfo.Length == 4)
        {
            car.Color = carsInfo[3];
        }

        cars.Add(car);
    }

    private static void ParseEngines(List<Engine> engines)
    {
        string[] engineInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string engineModel = engineInfo[0];
        int enginePower = int.Parse(engineInfo[1]);

        Engine engine = new Engine(engineModel, enginePower);

        if (engineInfo.Length >= 3)
        {
            if (engineInfo[2].All(d => char.IsDigit(d)))
            {
                engine.Displacements = engineInfo[2];
            }
            else
            {
                engine.Efficiency = engineInfo[2];
            }
        }
        if (engineInfo.Length == 4)
        {
            engine.Efficiency = engineInfo[3];
        }

        engines.Add(engine);
    }
}

