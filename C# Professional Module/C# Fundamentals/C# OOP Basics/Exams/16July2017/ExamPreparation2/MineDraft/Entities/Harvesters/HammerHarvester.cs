public class HammerHarvester : Harvester
{
    private const int OREOUTPUT_INCREASE_PERCENTAGE = 200;
    private const int PERCENT = 100;
    private const int ENERGY_REQUIREMENT_INCREASE = 2;
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += this.OreOutput * OREOUTPUT_INCREASE_PERCENTAGE / PERCENT;
        this.EnergyRequirement *= ENERGY_REQUIREMENT_INCREASE;
    }
}
