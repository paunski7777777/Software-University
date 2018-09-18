public class Axe : Weapon
{
    public Axe(string name, State state)
        : base(name, state)
    {
        this.State.MinDamage = 5;
        this.State.MaxDamage = 10;
        this.State.Sockets = 4;
    }
}
