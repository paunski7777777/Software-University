namespace _11GeometryCalculator
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string figure = Console.ReadLine();

            if (figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Console.WriteLine($"{TriangleArea(side, height):f2}");
            }
            else if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());

                Console.WriteLine($"{SquareArea(side):f2}");
            }
            else if (figure == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Console.WriteLine($"{RectangleArea(width, height):f2}");
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());

                Console.WriteLine($"{CircleArea(radius):f2}");
            }
        }

        private static double TriangleArea(double a, double h)
        {
            double result = (a * h) / 2;
            return result;
        }
        private static double SquareArea(double a)
        {
            double result = a * a;
            return result;
        }
        private static double RectangleArea(double a, double b)
        {
            double result = a * b;
            return result;
        }
        private static double CircleArea(double r)
        {
            double result = Math.PI * r * r;
            return result;
        }
    }
}