using System;
using System.Linq;

class PointinRectangle
{
    static void Main()
    {
        int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int topLeftX = coordinates[0];
        int topLeftY = coordinates[1];
        int bottomRightX = coordinates[2];
        int bottomRightY = coordinates[3];

        Rectangle rectangle = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);


        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] points = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int x = points[0];
            int y = points[1];

            Point point = new Point(x, y);

            bool contains = rectangle.Contains(point);

            Console.WriteLine(contains);
        }
    }
}

