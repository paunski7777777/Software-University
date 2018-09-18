using System;
public class GenericCountMethodDouble
{
    public static void Main()
    {
        var boxOfStrings = new GenericBox<double>();

        double n = double.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            double input = double.Parse(Console.ReadLine());

            boxOfStrings.Add(input);
        }

        double compareTo = double.Parse(Console.ReadLine());

        Console.WriteLine(boxOfStrings.CompareItems(compareTo));
    }
}

