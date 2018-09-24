namespace _03Megapixels
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int sum = width * height;
            double megapixels = Math.Round((sum / 1000000.0), 1);

            Console.WriteLine($"{width}x{height} => {megapixels}MP");
        }
    }
}