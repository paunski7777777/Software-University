namespace _09LongerLine
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

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double lengthFirstLine = GetLineLength(x1, y1, x2, y2);
            double lengthSecondLine = GetLineLength(x3, y3, x4, y4);

            if (lengthFirstLine >= lengthSecondLine)
            {
                bool isFirstCloser = GetCloserPoint(x1, y1, x2, y2);

                if (isFirstCloser)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else if (lengthFirstLine < lengthSecondLine)
            {
                bool isFirstCloser = GetCloserPoint(x3, y3, x4, y4);

                if (isFirstCloser)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }

        private static double GetLineLength(double x1, double y1, double x2, double y2)
        {
            double lineLength = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return lineLength;
        }

        private static bool GetCloserPoint(double x1, double y1, double x2, double y2)
        {
            double c1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double c2 = Math.Sqrt(x2 * x2 + y2 * y2);

            bool isClose = true;

            if (c1 < c2)
            {
                isClose = true;
            }
            else if (c1 > c2)
            {
                isClose = false;
            }

            return isClose;
        }
    }
}