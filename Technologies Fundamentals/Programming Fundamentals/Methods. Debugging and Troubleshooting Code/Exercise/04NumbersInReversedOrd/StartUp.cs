namespace _04NumbersInReversedOrd
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            double number = double.Parse(Console.ReadLine());

            Console.WriteLine(NumbersInReserveOrder(number));
        }

        private static double NumbersInReserveOrder(double n)
        {
            string toString = new String(n.ToString().Reverse().ToArray());

            return double.Parse(toString);
        }
    }
}