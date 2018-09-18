using System;
public class ShapesProgram
{
    public static void Main()
    {
        int radius = int.Parse(Console.ReadLine());
        IDrawable circle = new Circle(radius);

        int width = int.Parse(Console.ReadLine());
        int heigt = int.Parse(Console.ReadLine());
        IDrawable rectangle = new Rectangle(width, heigt);

        circle.Draw();
        rectangle.Draw();
    }
}

