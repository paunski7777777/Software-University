public abstract class Weapon
{
    public string Name { get; set; }
    public  virtual State State { get; set; }
    public Weapon(string name, State state)
    {
        this.Name = name;
        this.State = state;
    }
}