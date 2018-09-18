using System.Collections.Generic;
using System.Text;
public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private ICollection<ISoldier> privates;
    public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)this.privates;
    public void AddPrivate(ISoldier soldier)
    {
        this.privates.Add(soldier);
    }
    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName, salary)
    {
        privates = new List<ISoldier>();
    }
    public override string ToString()
    {
        var leutenantGeneralInfo = new StringBuilder()
            .AppendLine(base.ToString())
            .AppendLine("Privates:");

        foreach (var privateSoldier in privates)
        {
            leutenantGeneralInfo.AppendLine($"  {privateSoldier.ToString()}");
        }

        string result = leutenantGeneralInfo.ToString().TrimEnd();
        return result;
    }
}

