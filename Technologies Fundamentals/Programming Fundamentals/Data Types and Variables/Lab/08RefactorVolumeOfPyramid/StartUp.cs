namespace _08RefactorVolumeOfPyramid
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double sh = double.Parse(Console.ReadLine());
            double dul = double.Parse(Console.ReadLine());
            double v = double.Parse(Console.ReadLine());

            v = (dul * sh * v) / 3;

            Console.Write($"Length: ");
            Console.Write($"Width: ");
            Console.Write($"Height: ");
            Console.WriteLine($"Pyramid Volume: {v:F2}");
        }
    }
}