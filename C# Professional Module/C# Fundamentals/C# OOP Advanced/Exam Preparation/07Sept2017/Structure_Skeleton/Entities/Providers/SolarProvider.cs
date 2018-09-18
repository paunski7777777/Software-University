public class SolarProvider : Provider
{
    public SolarProvider(int iD, double energyOutput) 
        : base(iD, energyOutput)
    {
        this.Durability += 500;
    }
}
