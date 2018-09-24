namespace _16ComparingFloats
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double eps = 0.000001;
            bool equal = Math.Abs(a - b) < eps;

            Console.WriteLine(equal);
        }
    }
}