namespace _06CalculateTriangleArea
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = Area(width, height);

            Console.WriteLine($"{area}");
        }

        private static double Area(double width, double height)
        {
            double area = (width * height) / 2;

            return area;
        }
    }
}