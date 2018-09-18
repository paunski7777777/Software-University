using System;
public class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public string Displacements { get; set; }
    public string Efficiency { get; set; }
    public Engine(string model, int power)
    {
        this.Model = model;
        this.Power = power;
        this.Displacements = "n/a";
        this.Efficiency = "n/a";
    }
}

