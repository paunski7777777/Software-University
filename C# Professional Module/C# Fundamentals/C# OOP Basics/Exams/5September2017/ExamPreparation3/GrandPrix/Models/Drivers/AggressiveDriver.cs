public class AggressiveDriver : Driver
{
    private const double IncreaseFuelConsumption = 2.7;
    private const double IncreaseSpeed = 1.3;
    public AggressiveDriver(string name, Car car) 
        : base(name, car, IncreaseFuelConsumption)
    {
    }
    public override double Speed => base.Speed * IncreaseSpeed;
}

