using System;

public abstract class Provider : IProvider
{
    private const int DefaultDurability = 1000;
    private const double DurabilityDecrease = 100;

    private double durability;

    public double EnergyOutput { get; protected set; }
    public int ID { get; protected set; }
    public double Durability
    {
        get
        { return this.durability; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Brokent entity");
            }
            this.durability = value;
        }
    }

    protected Provider(int iD, double energyOutput)
    {
        this.ID = iD;
        this.EnergyOutput = energyOutput;
        this.Durability = DefaultDurability;
    }

    public void Broke()
    {
        this.Durability -= DurabilityDecrease;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine + $"Durability: {this.Durability}";
    }
}