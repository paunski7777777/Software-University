using System;
public class MordorsCruelPlan
{
    public static void Main()
    {
        string[] input = Console.ReadLine().ToLower().Split();

        Gandalf gandalf = new Gandalf();

        foreach (var food in input)
        {
            gandalf.EatFood(food);
        }

        Console.WriteLine(gandalf.Happiness);
        Console.WriteLine(gandalf.CalculateMood());
    }
}

