using System;
public class ClassBox
{
    public static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            Box box = new Box(length, width, height);

            double surfaceArea = box.CalculateSurfaceArea();
            double lateralSurfaceArea = box.CalculateLateralSurfaceArea();
            double volume = box.CalculateVolume();

            Console.WriteLine(box);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }
}

