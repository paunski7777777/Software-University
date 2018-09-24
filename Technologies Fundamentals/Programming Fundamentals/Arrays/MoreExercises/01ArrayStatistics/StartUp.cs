namespace _01ArrayStatistics
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();

            double min = array.Min();
            double max = array.Max();
            double sum = array.Sum();
            double avrg = array.Average();

            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {avrg}");
        }
    }
}