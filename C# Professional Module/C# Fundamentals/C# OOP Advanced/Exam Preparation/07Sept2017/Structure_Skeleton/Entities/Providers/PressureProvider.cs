public class PressureProvider : Provider
{
    public PressureProvider(int iD, double energyOutput) 
        : base(iD, energyOutput)
    {
        this.EnergyOutput *= 2;
        this.Durability -= 300;
    }
}