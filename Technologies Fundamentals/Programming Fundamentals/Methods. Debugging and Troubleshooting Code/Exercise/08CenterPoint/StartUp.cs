namespace _08CenterPoint
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine(PrintClosestPoint(x1, y1, x2, y2));
        }

        private static string PrintClosestPoint(double x1, double y1, double x2, double y2)
        {
            string result = string.Empty;

            double n = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            double m = Math.Pow(x2, 2) + Math.Pow(y2, 2);

            if (n <= m)
            {
                result = $"({x1}, {y1})";
            }
            else
            {
                result = $"({x2}, {y2})";
            }

            return result;
        }
    }
}