namespace _07MathPower
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine(MathPow(n, m));
        }

        private static double MathPow(double n, int m)
        {
            double sum = 1;

            for (int i = 0; i < m; i++)
            {
                sum *= n;
            }

            return sum;
        }
    }
}