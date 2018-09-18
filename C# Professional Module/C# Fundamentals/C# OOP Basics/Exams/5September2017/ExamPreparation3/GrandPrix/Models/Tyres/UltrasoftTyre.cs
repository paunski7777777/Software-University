using System;

public class UltrasoftTyre : Tyre
{
    public double Grip { get; private set; }
    public UltrasoftTyre(double hardness, double grip)
        : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }
    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(OutputMessages.BlownTyreMessage);
            }
            base.Degradation = value;
        }
    }
    public override void ReduceDegradation()
    {
        base.ReduceDegradation();
        this.Degradation -= this.Grip;
    }
}

