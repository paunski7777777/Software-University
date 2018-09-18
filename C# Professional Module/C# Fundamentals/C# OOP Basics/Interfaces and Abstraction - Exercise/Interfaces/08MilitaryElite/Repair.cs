public class Repair : IRepair
{
    public string PartName { get; private set; }

    public int HoursWorked { get; private set; }
    public Repair(string partName, int hoursWorked)
    {
        this.PartName = partName;
        this.HoursWorked = hoursWorked;
    }
    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
    }
}
