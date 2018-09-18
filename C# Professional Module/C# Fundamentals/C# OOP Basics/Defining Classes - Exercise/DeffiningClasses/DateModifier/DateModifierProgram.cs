using System;
class DateModifierProgram
{
    static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        var difference = DateModifier.CalculateDifference(firstDate, secondDate);

        Console.WriteLine(difference);
    }
}

