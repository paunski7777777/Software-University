using System;
using System.Text;
public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }
    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = "n/a";
        this.Color = "n/a";
    }
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{this.Model}:")
            .AppendLine($"  {this.Engine.Model}:")
            .AppendLine($"    Power: {this.Engine.Power}")
            .AppendLine($"    Displacement: {this.Engine.Displacements}")
            .AppendLine($"    Efficiency: {this.Engine.Efficiency}")
            .AppendLine($"  Weight: {this.Weight}")
            .AppendLine($"  Color: {this.Color}");

        return result.ToString().TrimEnd();
    }
}
