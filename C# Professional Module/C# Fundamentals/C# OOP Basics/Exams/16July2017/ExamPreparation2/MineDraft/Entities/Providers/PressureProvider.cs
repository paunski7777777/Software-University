public class PressureProvider : Provider
{
    private const int ENERGY_OUTPUT_INCREASE = 50;
    private const int PERCENT = 100;
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        this.EnergyOutput += this.EnergyOutput * ENERGY_OUTPUT_INCREASE / PERCENT;
    }
}

