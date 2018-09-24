namespace _02VehicleCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input1 = Console.ReadLine();

            var vehicles = new List<Vehicle>();

            while (!input1.Equals("End"))
            {
                string[] tokens1 = input1.Split();

                string type = CheckLetters(tokens1);
                string model = tokens1[1];
                string color = tokens1[2];
                int horsepower = int.Parse(tokens1[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsepower);
                vehicles.Add(vehicle);

                input1 = Console.ReadLine();
            }

            string input2 = Console.ReadLine();

            while (!input2.Equals("Close the Catalogue"))
            {
                foreach (var v in vehicles)
                {
                    string model = v.Model;

                    if (input2.Equals(model))
                    {
                        Console.WriteLine($"Type: {v.Type}");
                        Console.WriteLine($"Model: {v.Model}");
                        Console.WriteLine($"Color: {v.Color}");
                        Console.WriteLine($"Horsepower: {v.Horsepower}");
                    }
                }

                input2 = Console.ReadLine();
            }

            int carsCount = vehicles.Where(v => v.Type == "Car").Count();
            int trucksCount = vehicles.Where(v => v.Type == "Truck").Count();

            if (carsCount > 0)
            {
                double averageHPforCars = vehicles.Where(v => v.Type == "Car").Select(hp => hp.Horsepower).Average();

                Console.WriteLine($"Cars have average horsepower of: {averageHPforCars:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }

            if (trucksCount > 0)
            {
                double averageHPforTrucks = vehicles.Where(v => v.Type == "Truck").Select(hp => hp.Horsepower).Average();

                Console.WriteLine($"Trucks have average horsepower of: {averageHPforTrucks:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }

        private static string CheckLetters(string[] tokens1)
        {
            string type = string.Empty;

            if (tokens1[0].Length == 3)
            {
                type = tokens1[0][0].ToString().ToUpper() + tokens1[0][1].ToString().ToLower() + tokens1[0][2].ToString().ToLower();
            }
            else
            {
                type = tokens1[0][0].ToString().ToUpper() + tokens1[0][1].ToString().ToLower() + tokens1[0][2].ToString().ToLower() + tokens1[0][3].ToString().ToLower() + tokens1[0][4].ToString().ToLower();
            }

            return type;
        }

        public class Vehicle
        {
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int Horsepower { get; set; }

            public Vehicle(string type, string model, string color, int horsepower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.Horsepower = horsepower;
            }
        }
    }
}