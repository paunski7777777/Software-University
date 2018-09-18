using System;
using System.Text;

public abstract class Provider
{
    private const int MAX_ENERGY_OUTPUT = 10000;
    public string Id { get; set; }
    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }
            energyOutput = value;
        }
    }
    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }
    public override string ToString()
    {
        var providerInfo = new StringBuilder();

        string type = this.GetType().Name;
        int index = type.IndexOf("Provider");
        type = type.Remove(index);

        providerInfo
            .AppendLine($"{type} Provider - {this.Id}")
            .AppendLine($"Energy Output: {this.EnergyOutput}");

        return providerInfo.ToString().TrimEnd();
    }
}

