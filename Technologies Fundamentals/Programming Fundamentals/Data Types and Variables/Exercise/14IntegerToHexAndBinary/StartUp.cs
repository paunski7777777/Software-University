namespace _14IntegerToHexAndBinary
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string toHex = Convert.ToString(n, 16).ToUpper();
            string toBin = Convert.ToString(n, 2).ToUpper();

            Console.WriteLine(toHex);
            Console.WriteLine(toBin);
        }
    }
}