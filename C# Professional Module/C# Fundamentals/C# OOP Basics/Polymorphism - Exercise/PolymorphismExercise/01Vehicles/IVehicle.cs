public interface IVehicle
{
    double FuelQuantity { get; }
    double FuelConsumptionPerKilometer { get; }
    double TankCapacity { get; }
    void Drive(double distance);
    void Refuel(double amount);
}

