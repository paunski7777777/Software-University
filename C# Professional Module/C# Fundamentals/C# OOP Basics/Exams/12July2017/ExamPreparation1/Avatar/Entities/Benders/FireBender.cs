public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggresion)
        : base(name, power)
    {
        this.HeatAggression = heatAggresion;
    }

    public double HeatAggression { get; set; }

    public override double GetTotalPower()
    {
        return this.HeatAggression * base.Power;
    }
    public override string ToString()
    {
        return $"{base.ToString()} Heat Aggression: {this.HeatAggression:f2}";
    }
}

