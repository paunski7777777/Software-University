using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalEnergyStored;
    private double totalMinedOre;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.totalEnergyStored = 0;
        this.totalMinedOre = 0;
        this.mode = "Full";

    }
    public string RegisterHarvester(List<string> arguments)
    {
        string result = string.Empty;

        try
        {
            string type = arguments[0];
            string id = arguments[1];
            double oreOutput = double.Parse(arguments[2]);
            double energyRequirement = double.Parse(arguments[3]);
            Harvester harvester = null;

            switch (type)
            {
                case "Sonic":
                    int sonicFactor = int.Parse(arguments[4]);
                    harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                    this.harvesters[harvester.Id] = harvester;
                    break;

                case "Hammer":
                    harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                    this.harvesters[harvester.Id] = harvester;
                    break;
            }


            result = $"Successfully registered {type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ae)
        {
            result = ae.Message;
        }

        return result;
    }
    public string RegisterProvider(List<string> arguments)
    {
        string result = string.Empty;

        try
        {
            string type = arguments[0];
            string id = arguments[1];
            double energyOutput = double.Parse(arguments[2]);
            Provider provider = null;

            switch (type)
            {
                case "Solar":
                    provider = new SolarProvider(id, energyOutput);
                    this.providers[provider.Id] = provider;
                    break;

                case "Pressure":
                    provider = new PressureProvider(id, energyOutput);
                    this.providers[provider.Id] = provider;
                    break;
            }

            result = $"Successfully registered {type} Provider - {provider.Id}";
        }
        catch (ArgumentException ae)
        {
            result = ae.Message;
        }

        return result;
    }
    public string Day()
    {
        double energyPerDay = 0;
        double orePerDay = 0;
        double harvestNeededEnergyPerDay = 0;

        energyPerDay = providers.Sum(p => p.Value.EnergyOutput);
        totalEnergyStored += energyPerDay;

        harvestNeededEnergyPerDay += harvesters.Sum(h => h.Value.EnergyRequirement);

        if (totalEnergyStored >= harvestNeededEnergyPerDay)
        {
            if (this.mode == "Full")
            {
                orePerDay += harvesters.Sum(h => h.Value.OreOutput);
                totalEnergyStored -= harvestNeededEnergyPerDay;
            }
            else if (this.mode == "Half")
            {
                orePerDay += harvesters.Sum(h => h.Value.OreOutput) * 50 / 100;
                totalEnergyStored -= harvestNeededEnergyPerDay * 60 / 100;
            }

            totalMinedOre += orePerDay;
        }

        var result = new StringBuilder()
            .AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {energyPerDay}")
            .AppendLine($"Plumbus Ore Mined: {orePerDay}");

        return result.ToString().TrimEnd();
    }
    public string Mode(List<string> arguments)
    {
        string modeToChange = arguments[0];

        if (modeToChange == "Full")
        {
            this.mode = modeToChange;
        }
        else if (modeToChange == "Half")
        {
            this.mode = modeToChange;
        }
        else
        {
            this.mode = modeToChange;
        }

        return $"Successfully changed working mode to {this.mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        string result = string.Empty;

        string id = arguments[0];

        if (harvesters.ContainsKey(id))
        {
            result = harvesters[id].ToString();
        }
        if (providers.ContainsKey(id))
        {
            result = providers[id].ToString();
        }

        if (result != string.Empty)
        {
            return result;
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }
    public string ShutDown()
    {
        var result = new StringBuilder()
            .AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {totalEnergyStored}")
            .AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return result.ToString().TrimEnd();
    }

}

