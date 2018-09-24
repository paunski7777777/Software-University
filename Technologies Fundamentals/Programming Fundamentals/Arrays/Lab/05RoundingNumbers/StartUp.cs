namespace _05RoundingNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} => {Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}