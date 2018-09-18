using System;
public class GenericBoxofString
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var boxOfStrings = new GenericBox<string>();
            string input = Console.ReadLine();

            boxOfStrings.Add(input);

            Console.WriteLine(boxOfStrings);
        }
    }
}

