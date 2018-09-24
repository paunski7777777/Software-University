namespace _05ClosestTwoPoints
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Point[] pointsArray = new Point[n];

            for (int i = 0; i < n; i++)
            {
                pointsArray[i] = ReadPoint(Console.ReadLine());
            }

            Point[] closestPoints = ClosestPoints(pointsArray);

            foreach (Point point in closestPoints)
            {
                Console.WriteLine($"({point.X}, {point.Y})");
            }
        }

        private static Point ReadPoint(string input)
        {
            int[] coordinates = input.Split().Select(int.Parse).ToArray();

            return new Point() { X = coordinates[0], Y = coordinates[1] };
        }

        private static Point[] ClosestPoints(Point[] array)
        {
            Point[] closestPoints = new Point[2];

            double minimalDistance = double.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (CalculateDistance(array[i], array[j]) < minimalDistance)
                    {
                        minimalDistance = CalculateDistance(array[i], array[j]);
                        closestPoints[0] = array[i];
                        closestPoints[1] = array[j];
                    }
                }
            }

            Console.WriteLine("{0:F3}", minimalDistance);

            return closestPoints;
        }

        private static double CalculateDistance(Point point1, Point point2)
        {
            int deltaX = point1.X - point2.X;
            int deltaY = point1.Y - point2.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}