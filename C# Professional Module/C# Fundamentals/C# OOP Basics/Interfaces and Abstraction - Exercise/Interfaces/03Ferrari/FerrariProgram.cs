using System;
public class FerrariProgram
{
    public static void Main()
    {
        string driver = Console.ReadLine();
        ICar ferrari = new Ferrari(driver);

        Console.WriteLine(ferrari);
    }
}

