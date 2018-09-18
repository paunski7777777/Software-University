using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> wars;
    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            ["Air"] = new Nation(),
            ["Water"] = new Nation(),
            ["Fire"] = new Nation(),
            ["Earth"] = new Nation()
        };
        this.wars = new List<string>();
    }
    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondaryParameter = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                Bender airBender = new AirBender(name, power, secondaryParameter);
                this.nations[type].AddBender(airBender);
                break;

            case "Water":
                Bender waterBender = new WaterBender(name, power, secondaryParameter);
                this.nations[type].AddBender(waterBender);
                break;

            case "Fire":
                Bender fireBender = new FireBender(name, power, secondaryParameter);
                this.nations[type].AddBender(fireBender);
                break;

            case "Earth":
                Bender earthBender = new EarthBender(name, power, secondaryParameter);
                this.nations[type].AddBender(earthBender);
                break;
        }
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                Monument airMonument = new AirMonument(name, affinity);
                this.nations[type].AddMonument(airMonument);
                break;

            case "Water":
                Monument waterMonument = new WaterMonument(name, affinity);
                this.nations[type].AddMonument(waterMonument);
                break;

            case "Fire":
                Monument fireMonument = new FireMonument(name, affinity);
                this.nations[type].AddMonument(fireMonument);
                break;

            case "Earth":
                EarthMonument earthMonument = new EarthMonument(name, affinity);
                this.nations[type].AddMonument(earthMonument);
                break;
        }
    }
    public string GetStatus(string nationsType)
    {
        return $"{nationsType} Nation" + Environment.NewLine + this.nations[nationsType].ToString();
    }
    public void IssueWar(string nationsType)
    {
        this.wars.Add(nationsType);
        double winner = nations.Max(w => w.Value.GetTotalPoints());

        foreach (var nation in nations)
        {
            if (nation.Value.GetTotalPoints() != winner)
            {
                nation.Value.Lose();
            }
        }
    }
    public string GetWarsRecord()
    {
        var warsInfo = new StringBuilder();

        for (int i = 0; i < this.wars.Count; i++)
        {
            warsInfo.AppendLine($"War {i + 1} issued by {this.wars[i]}");
        }

        return warsInfo.ToString().TrimEnd();
    }

}

