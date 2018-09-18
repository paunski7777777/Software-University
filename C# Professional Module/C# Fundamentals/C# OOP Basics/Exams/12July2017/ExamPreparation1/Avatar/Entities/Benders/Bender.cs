public abstract class Bender
{
    public string Name { get; set; }
    public int Power { get; set; }
    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }
    public abstract double GetTotalPower();
    public override string ToString()
    {
        string name = this.GetType().Name;
        int index = name.IndexOf("Bender");
        name = name.Insert(index, " ");

        return $"###{name}: {this.Name}, Power: {this.Power},";
    }
}

