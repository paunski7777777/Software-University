namespace StorageMaster.Factories
{
    using StorageMaster.Entities.Vehicles;
    using System;

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType)
        {
            Vehicle vehicle = null;
            switch (vehicleType)
            {
                case "Van":
                    vehicle = new Van();
                    break;
                case "Truck":
                    vehicle = new Truck();
                    break;
                case "Semi":
                    vehicle = new Semi();
                    break;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
