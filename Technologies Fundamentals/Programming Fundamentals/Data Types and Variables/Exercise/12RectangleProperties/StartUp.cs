namespace _12RectangleProperties
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double P = 2 * width + 2 * height;
            double S = width * height;
            double c = width * width + height * height;
            double d = Math.Sqrt(c);

            Console.WriteLine(P);
            Console.WriteLine(S);
            Console.WriteLine(d);
        }
    }
}