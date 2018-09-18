using System;
public class Truck : Vehicle
{
    private const double TRUCK_EXTRA_CONSUMPION = 1.6;
    private const double TRUCK_FUEL_LOSS = 0.95;

    public Truck(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
    {
    }
    public override double FuelConsumptionPerKilometer => base.FuelConsumptionPerKilometer + TRUCK_EXTRA_CONSUMPION;
    public override void Refuel(double amount)
    {
        if (amount < 1)
        {
            throw new ArgumentException(FUEL_ERROR);
        }
        if (this.FuelQuantity + amount * TRUCK_FUEL_LOSS > this.TankCapacity)
        {
            throw new ArgumentException(string.Format(FUEL_OVERFLOW, amount));
        }

        this.FuelQuantity += amount * TRUCK_FUEL_LOSS;
    }
}

