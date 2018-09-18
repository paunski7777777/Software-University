using System;
public class Bus : Vehicle
{
    private const double BUS_EXTRA_CONSUMPTION = 1.4;

    public Bus(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
    {
    }
    public override void Drive(double distance)
    {
        double fuelNeeded = distance * (this.FuelConsumptionPerKilometer + BUS_EXTRA_CONSUMPTION);

        if (fuelNeeded > this.FuelQuantity)
        {
            throw new ArgumentException(string.Format(LOW_FUEL, this.GetType().Name));
        }

        this.FuelQuantity -= fuelNeeded;
    }
    public void DriveWithoutPeople(double distance)
    {
        base.Drive(distance);
    }
}

