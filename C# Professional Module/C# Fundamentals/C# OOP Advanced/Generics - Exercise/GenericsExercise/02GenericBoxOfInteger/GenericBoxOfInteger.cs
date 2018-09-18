using System;
public class GenericBoxOfInteger
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var boxOfStrings = new GenericBox<int>();
            int input = int.Parse(Console.ReadLine());

            boxOfStrings.Add(input);

            Console.WriteLine(boxOfStrings);
        }
    }
}

