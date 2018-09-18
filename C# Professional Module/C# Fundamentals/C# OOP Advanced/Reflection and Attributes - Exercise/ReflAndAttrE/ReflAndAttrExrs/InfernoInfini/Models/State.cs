public class State
{
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int Sockets { get; set; }
    public State(int minDamage, int maxDamage, int sockets)
    {
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.Sockets = sockets;
    }
}
