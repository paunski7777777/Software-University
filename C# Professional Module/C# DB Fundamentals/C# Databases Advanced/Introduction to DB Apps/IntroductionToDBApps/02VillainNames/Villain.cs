public class Villain
{
    public string Name { get; set; }
    public int MinionsCount { get; set; }

    public Villain(string name, int minionsCount)
    {
        this.Name = name;
        this.MinionsCount = minionsCount;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.MinionsCount}";
    }
}