using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    public List<Bender> Benders { get; set; }
    public List<Monument> Monuments { get; set; }
    public Nation()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }
    public void AddBender(Bender bender)
    {
        this.Benders.Add(bender);
    }
    public void AddMonument(Monument monument)
    {
        this.Monuments.Add(monument);
    }
    public double GetTotalPoints()
    {
        double power = this.Benders.Sum(b => b.GetTotalPower());
        double bonus = this.Monuments.Sum(m => m.GetMonumentBonus());

        return power += power / 100 * bonus;
    }
    public void Lose()
    {
        this.Benders.Clear();
        this.Monuments.Clear();
    }
    public override string ToString()
    {
        var nationInfo = new StringBuilder();

        if (this.Benders.Count > 0)
        {
            nationInfo.AppendLine("Benders:");
            nationInfo.AppendLine(string.Join(Environment.NewLine, this.Benders));
        }
        else
        {
            nationInfo.AppendLine("Benders: None");
        }

        if (this.Monuments.Count > 0)
        {
            nationInfo.AppendLine("Monuments:");
            nationInfo.AppendLine(string.Join(Environment.NewLine, this.Monuments));
        }
        else
        {
            nationInfo.AppendLine("Monuments: None");
        }

        return nationInfo.ToString().TrimEnd();
    }
}

