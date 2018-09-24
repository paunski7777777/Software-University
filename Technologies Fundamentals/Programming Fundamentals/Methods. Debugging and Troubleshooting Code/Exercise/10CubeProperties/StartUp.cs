namespace _10CubeProperties
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            if (parameter == "face")
            {
                Console.WriteLine($"{FaceDiagonals(a):f2}");
            }
            else if (parameter == "space")
            {
                Console.WriteLine($"{SpaceDiagonals(a):f2}");
            }
            else if (parameter == "volume")
            {
                Console.WriteLine($"{Volume(a):f2}");

            }
            else if (parameter == "area")
            {
                Console.WriteLine($"{SurfaceArea(a):f2}");
            }
        }

        private static double FaceDiagonals(double a)
        {
            double result = Math.Sqrt(2 * Math.Pow(a, 2));
            return result;
        }
        private static double SpaceDiagonals(double a)
        {
            double result = Math.Sqrt(3 * Math.Pow(a, 2));
            return result;
        }
        private static double Volume(double a)
        {
            double result = Math.Pow(a, 3);
            return result;
        }
        private static double SurfaceArea(double a)
        {
            double result = 6 * Math.Pow(a, 2);
            return result;
        }
    }
}