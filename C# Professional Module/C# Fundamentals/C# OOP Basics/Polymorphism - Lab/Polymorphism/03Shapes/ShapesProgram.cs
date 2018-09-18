using System;
using System.Collections.Generic;

public class ShapesProgram
{
    public static void Main()
    {
        var shapes = new List<Shape>
        {
            new Circle(3.5),
            new Rectangle(3.5, 1.2),
            new Rectangle(1.5, 1.5),
            new Rectangle(3.4, 1.5),
            new Circle(3.6)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}

