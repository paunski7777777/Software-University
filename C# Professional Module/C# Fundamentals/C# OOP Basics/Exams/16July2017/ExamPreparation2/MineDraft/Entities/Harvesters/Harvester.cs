using System;
using System.Text;

public abstract class Harvester
{
    private const double MAX_ENERGY_REQUIREMENT = 20000;
    public string Id { get; set; }
    private double oreOutput;
    private double energyRequirement;

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
            }
            oreOutput = value;
        }
    }
    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > MAX_ENERGY_REQUIREMENT)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }
            energyRequirement = value;
        }
    }
    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }
    public override string ToString()
    {
        var harvesterInfo = new StringBuilder();

        string type = this.GetType().Name;
        int index = type.IndexOf("Harvester");
        type = type.Remove(index);

        harvesterInfo
            .AppendLine($"{type} Harvester - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .AppendLine($"Energy Requirement: {this.energyRequirement}");

        return harvesterInfo.ToString().TrimEnd();
    }
}

