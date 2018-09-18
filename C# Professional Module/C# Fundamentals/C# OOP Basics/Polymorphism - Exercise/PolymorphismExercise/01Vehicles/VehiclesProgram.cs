using System;
public class VehiclesProgram
{
    public static void Main()
    {
        IVehicle car = CreateCar();
        IVehicle truck = CreateTruck();
        IVehicle bus = CreateBus();

        ProcessOfVehicles(car, truck, bus);

        PrintVehicles(car, truck, bus);
    }

    private static void PrintVehicles(IVehicle car, IVehicle truck, IVehicle bus)
    {
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static void ProcessOfVehicles(IVehicle car, IVehicle truck, IVehicle bus)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string command = input[0];
            string vehicleType = input[1];

            IVehicle vehicleTo = GetTypeOfVehicle(car, truck, bus, vehicleType);

            switch (command)
            {
                case "Drive":
                    DriveVehicle(input, vehicleTo);
                    break;

                case "Refuel":
                    RefuelVehicle(input, vehicleTo);
                    break;

                case "DriveEmpty":
                    DriveEmptyBus(input, vehicleTo);
                    break;
            }
        }
    }

    private static void DriveEmptyBus(string[] input, IVehicle vehicleTo)
    {
        try
        {
            double distance = double.Parse(input[2]);
            ((Bus)vehicleTo).DriveWithoutPeople(distance);
            Console.WriteLine($"{vehicleTo.GetType().Name} travelled {distance} km");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static void RefuelVehicle(string[] input, IVehicle vehicleTo)
    {
        try
        {
            double liters = double.Parse(input[2]);
            vehicleTo.Refuel(liters);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static void DriveVehicle(string[] input, IVehicle vehicleTo)
    {
        try
        {
            double distance = double.Parse(input[2]);
            vehicleTo.Drive(distance);
            Console.WriteLine($"{vehicleTo.GetType().Name} travelled {distance} km");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static IVehicle GetTypeOfVehicle(IVehicle car, IVehicle truck, IVehicle bus, string vehicleType)
    {
        IVehicle vehicleTo = null;

        if (vehicleType == "Car")
        {
            vehicleTo = car;
        }
        else if (vehicleType == "Truck")
        {
            vehicleTo = truck;
        }
        else
        {
            vehicleTo = bus;
        }

        return vehicleTo;
    }

    private static IVehicle CreateTruck()
    {
        string[] truckInfo = Console.ReadLine().Split();
        double truckFuelQuantity = double.Parse(truckInfo[1]);
        double truckFuelConsumptionPerKilometer = double.Parse(truckInfo[2]);
        double truckTankCapacity = double.Parse(truckInfo[3]);

        IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumptionPerKilometer, truckTankCapacity);
        return truck;
    }

    private static IVehicle CreateCar()
    {
        string[] carInfo = Console.ReadLine().Split();
        double carFuelQuantity = double.Parse(carInfo[1]);
        double carFuelConsumptionPerKilometer = double.Parse(carInfo[2]);
        double carTankCapacity = double.Parse(carInfo[3]);

        IVehicle car = new Car(carFuelQuantity, carFuelConsumptionPerKilometer, carTankCapacity);
        return car;
    }

    private static IVehicle CreateBus()
    {
        string[] busInfo = Console.ReadLine().Split();
        double busFuelQuantity = double.Parse(busInfo[1]);
        double busFuelConsumptionPerKilometer = double.Parse(busInfo[2]);
        double busTankCapacity = double.Parse(busInfo[3]);

        IVehicle bus = new Bus(busFuelQuantity, busFuelConsumptionPerKilometer, busTankCapacity);
        return bus;
    }
}
