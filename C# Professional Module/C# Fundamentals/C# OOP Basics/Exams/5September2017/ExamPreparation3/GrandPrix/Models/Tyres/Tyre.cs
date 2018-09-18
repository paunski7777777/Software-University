using System;

public abstract class Tyre
{
    private double degradation;

    public string Name { get; protected set; }
    public double Hardness { get; protected set; }
    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(OutputMessages.BlownTyreMessage);
            }
            degradation = value;
        }
    }
    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }
    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}

