using System;
public class CarsProgram
{
    public static void Main()
    {
        ICar seat = new Seat("Leon", "Grey");
        ICar tesla = new Tesla("Model 3", "Red", 2);

        Console.WriteLine(seat);
        Console.WriteLine(tesla);
    }
}

