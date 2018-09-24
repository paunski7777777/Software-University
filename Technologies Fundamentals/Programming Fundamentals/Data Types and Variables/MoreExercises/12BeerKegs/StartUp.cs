namespace _12BeerKegs
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double volume = 0;
            string biggestKeg = string.Empty;
            double biggestKegVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                volume = Math.PI * radius * radius * height;

                if (volume > biggestKegVolume)
                {
                    biggestKegVolume = volume;
                    biggestKeg = model;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}