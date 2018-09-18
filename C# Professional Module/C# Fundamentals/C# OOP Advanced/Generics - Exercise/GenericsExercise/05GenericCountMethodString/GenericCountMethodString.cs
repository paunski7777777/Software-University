using System;
public class GenericCountMethodString
{
    public static void Main()
    {
        var boxOfStrings = new GenericBox<string>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            boxOfStrings.Add(input);
        }

        string compareTo = Console.ReadLine();

        Console.WriteLine(boxOfStrings.CompareItems(compareTo));
    }
}

