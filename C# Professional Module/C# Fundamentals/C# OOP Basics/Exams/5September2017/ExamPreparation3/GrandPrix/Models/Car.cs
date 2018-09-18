using System;

public class Car
{
    private const int TankMaxCapacity = 160;

    private double fuelAmount;
    public int Hp { get; private set; }
    public Tyre Tyre { get; private set; }
    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(OutputMessages.OutOfFuelMessage);
            }

            fuelAmount = Math.Min(value, TankMaxCapacity);
        }
    }
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void CompleteLap(int trackLength, double fuelConsumption)
    {
        this.FuelAmount -= trackLength * fuelConsumption;

        this.Tyre.ReduceDegradation();
    }
}

