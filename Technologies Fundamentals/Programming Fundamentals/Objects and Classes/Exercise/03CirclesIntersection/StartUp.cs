namespace _03CirclesIntersection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Circle c1 = ReadCircle(Console.ReadLine());
            Circle c2 = ReadCircle(Console.ReadLine());

            int deltaX = c1.Center.X - c2.Center.X;
            int deltaY = c1.Center.Y - c2.Center.Y;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distance > c1.Radius + c2.Radius)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
        }

        private static Circle ReadCircle(string input)
        {
            int[] input2 = input.Split().Select(int.Parse).ToArray();

            return new Circle { Center = new Point { X = input2[0], Y = input2[1] }, Radius = input2[2] };
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public class Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
        }
    }
}