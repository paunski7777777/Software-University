using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var stones = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

        Lake lake = new Lake(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}

