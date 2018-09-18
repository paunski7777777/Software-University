using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Constants.SystemShutdown);
        sb.AppendLine(string.Format(Constants.TotalEnergyStored, this.providerController.TotalEnergyProduced));
        sb.AppendLine(string.Format(Constants.TotalPlumbsOred, this.harvesterController.OreProduced));

        return sb.ToString().Trim();
    }
}