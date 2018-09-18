using System;

public abstract class Driver
{
    private const double BoxDefaultTime = 20;
    public string Name { get; protected set; }
    public double TotalTime { get; set; }
    public Car Car { get; protected set; }
    public double FuelConsumptionPerKm { get; protected set; }
    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0;
        this.IsRacing = true;
    }
    public bool IsRacing { get; private set; }
    public string FailureReason { get; private set; }
    private string Status => IsRacing ? this.TotalTime.ToString("f3") : this.FailureReason;
    public void RefuelCar(string[] methodArgs)
    {
        this.Box();

        double fuelAmount = double.Parse(methodArgs[0]);

        this.Car.Refuel(fuelAmount);
    }
    public void ChangeTyres(Tyre tyre)
    {
        this.Box();

        this.Car.ChangeTyre(tyre);
    }
    private void Box()
    {
        this.TotalTime += BoxDefaultTime;
    }
    public void CompleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);

        this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
    }
    public void Fail(string message)
    {
        this.IsRacing = false;
        this.FailureReason = message;
    }
    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }
}

