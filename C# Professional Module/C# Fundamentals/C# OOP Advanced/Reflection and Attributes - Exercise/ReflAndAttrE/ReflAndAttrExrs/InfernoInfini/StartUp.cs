using System;
public class Program
{
    public static void Main()
    {
        State state = new State(1, 2, 3);
        Weapon axe = new Axe("pesho", state);
        Console.WriteLine(axe.State.MaxDamage);
    }
}
