using System;
public abstract class Vehicle : IVehicle
{
    public const string FUEL_ERROR = "Fuel must be a positive number";
    public const string LOW_FUEL = "{0} needs refueling";
    public const string FUEL_OVERFLOW = "Cannot fit {0} fuel in the tank";

    private double fuelQuantity;
    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException(FUEL_ERROR);
            }

            if (value > this.TankCapacity)
            {
                fuelQuantity = 0;
            }
            else
            {
                fuelQuantity = value;
            }
        }
    }
    public virtual double FuelConsumptionPerKilometer { get; protected set; }
    public double TankCapacity { get; protected set; }
    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKilometer = fuelConsumptionPerKm;
    }
    public virtual void Drive(double distance)
    {
        var fuelNeeded = distance * this.FuelConsumptionPerKilometer;

        if (fuelNeeded > this.FuelQuantity)
        {
            throw new ArgumentException(string.Format(LOW_FUEL, this.GetType().Name));
        }

        this.FuelQuantity -= fuelNeeded;
    }
    public virtual void Refuel(double amount)
    {
        if (amount < 1)
        {
            throw new ArgumentException(FUEL_ERROR);
        }

        if (this.FuelQuantity + amount > this.TankCapacity)
        {
            throw new ArgumentException(string.Format(FUEL_OVERFLOW, amount));
        }

        this.FuelQuantity += amount;
    }
    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}

