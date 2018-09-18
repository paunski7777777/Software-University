using System;
using System.Collections.Generic;
using System.Linq;

class RectangleIntersection
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int numbersOfRectangle = input[0];
        int numberOfCheks = input[1];

        var rectangles = new List<Rectangle>();

        for (int i = 0; i < numbersOfRectangle; i++)
        {
            string[] inputLine = Console.ReadLine().Split();

            string id = inputLine[0];
            double witdh = double.Parse(inputLine[1]);
            double height = double.Parse(inputLine[2]);
            double x = double.Parse(inputLine[3]);
            double y = double.Parse(inputLine[4]);

            Rectangle rectangle = new Rectangle(id, witdh, height, x, y);

            rectangles.Add(rectangle);
        }

        for (int i = 0; i < numberOfCheks; i++)
        {
            string[] cheks = Console.ReadLine().Split();
            string first = cheks[0];
            string second = cheks[1];

            var firstRectangle = rectangles.Where(r => r.Id == first).First();
            var secondRectangle = rectangles.Where(r => r.Id == second).First();

            Console.WriteLine(firstRectangle.Intersection(secondRectangle));
        }
    }
}

