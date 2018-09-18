public abstract class Monument
{
    public string Name { get; set; }
    public Monument(string name)
    {
        this.Name = name;
    }
    public abstract double GetMonumentBonus();
    public override string ToString()
    {
        string name = this.GetType().Name;
        int index = name.IndexOf("Monument");
        name = name.Insert(index, " ");

        return $"###{name}: {this.Name},";
    }
}

