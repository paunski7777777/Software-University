namespace _04DistanceBetweenPoints
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Point p1 = PointReader(Console.ReadLine());
            Point p2 = PointReader(Console.ReadLine());

            Console.WriteLine($"{CalculateDistance(p1, p2):f3}");
        }

        private static Point PointReader(string input)
        {
            int[] coord = input.Split().Select(int.Parse).ToArray();
            return new Point() { X = coord[0], Y = coord[1] };
        }

        private static double CalculateDistance(Point p1, Point p2)
        {
            double deltaX = p1.X - p2.X;
            double deltaY = p1.Y - p2.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}