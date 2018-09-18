using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    public List<string> Addons { get; set; }
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.HorsePower += this.HorsePower * 50 / 100;
        this.Suspension -= this.Suspension * 25 / 100;
        this.Addons = new List<string>();
    }
    public override void TuneCar(int tuneIndex, string addOn)
    {
        base.TuneCar(tuneIndex, addOn);

        this.Addons.Add(addOn);
    }
    public override string ToString()
    {
        var carInfo = new StringBuilder(base.ToString());

        if (this.Addons.Count > 0)
        {
            carInfo.AppendLine($"Add-ons: {string.Join(", ", this.Addons)}");
        }
        else
        {
            carInfo.AppendLine("Add-ons: None");
        }

        string result = carInfo.ToString().TrimEnd();

        return result;
    }
}

