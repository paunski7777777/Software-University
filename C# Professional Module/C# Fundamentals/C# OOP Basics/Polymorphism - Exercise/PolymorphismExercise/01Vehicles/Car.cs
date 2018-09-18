using System;
public class Car : Vehicle
{
    private const double CAR_EXTRA_CONSUMPTION = 0.9;
    public override double FuelConsumptionPerKilometer => base.FuelConsumptionPerKilometer + CAR_EXTRA_CONSUMPTION;
    public Car(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
    {

    }
}

