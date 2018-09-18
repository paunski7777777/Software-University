using System.Collections.Generic;
using System.Text;
public class Engineer : SpecialisedSoldier, IEngineer
{
    private ICollection<IRepair> repairs;
    public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)repairs;
    public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<IRepair>();
    }
    public void AddRepair(IRepair repair)
    {
        repairs.Add(repair);
    }
    public override string ToString()
    {
        var engineerInfo = new StringBuilder()
            .AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corps.ToString()}")
            .AppendLine("Repairs:");

        foreach (var repair in repairs)
        {
            engineerInfo.AppendLine($"  {repair.ToString()}");
        }

        string result = engineerInfo.ToString().TrimEnd();
        return result;
    }
}

