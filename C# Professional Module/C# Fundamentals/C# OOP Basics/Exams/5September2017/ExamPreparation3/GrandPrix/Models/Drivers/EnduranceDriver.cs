public class EnduranceDriver : Driver
{
    private const double IncreaseFuelConsumption = 1.5;
    public EnduranceDriver(string name, Car car)
        : base(name, car, IncreaseFuelConsumption)
    {
    }
}

