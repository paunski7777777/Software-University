using System;
class DrawingTool
{
    static void Main()
    {
        string figure = Console.ReadLine();

        if (figure == "Square")
        {
            int size = int.Parse(Console.ReadLine());

            Square square = new Square(size);
            square.Draw();
        }
        else
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(a, b);
            rectangle.Draw();
        }
    }
}

